using FishNet.Connection;
using FishNet.Object;
using UnityEngine;

namespace ProjetoLuz.Player
{
    public sealed class PlayerPush : NetworkBehaviour
    {
        [SerializeField] private PlayerInputReader _input;
        [SerializeField] private PlayerMotor _motor;
        [SerializeField] private Transform _aim;
        [SerializeField] private PushSettings _settings;

        private readonly RaycastHit[] _aimHits = new RaycastHit[8];

        private float _lastLocalPushTime = float.NegativeInfinity;
        private float _lastServerPushTime = float.NegativeInfinity;

        private void OnEnable()
        {
            _input.PushPressed += TryPush;
        }

        private void OnDisable()
        {
            _input.PushPressed -= TryPush;
        }

        private void TryPush()
        {
            if (!PushRule.IsCooldownOver(_lastLocalPushTime, Time.time, _settings.Cooldown))
                return;

            if (!TryFindTarget(out var target))
                return;

            _lastLocalPushTime = Time.time;
            RequestPush(target, _aim.forward);
        }

        private bool TryFindTarget(out PlayerPush target)
        {
            var hitCount = Physics.SphereCastNonAlloc(
                _aim.position, _settings.AimRadius, _aim.forward, _aimHits, _settings.Range,
                Physics.AllLayers, QueryTriggerInteraction.Ignore);

            target = null;
            var closestDistance = float.MaxValue;
            for (var i = 0; i < hitCount; i++)
            {
                var hit = _aimHits[i];
                if (hit.distance >= closestDistance || !hit.collider.TryGetComponent(out PlayerPush candidate) || candidate == this)
                    continue;

                target = candidate;
                closestDistance = hit.distance;
            }

            return target != null;
        }

        [ServerRpc]
        private void RequestPush(PlayerPush target, Vector3 aimDirection)
        {
            if (target == null || target == this)
                return;

            if (!PushRule.IsCooldownOver(_lastServerPushTime, Time.time, _settings.Cooldown))
                return;

            var maxRange = _settings.Range + _settings.ServerRangeTolerance;
            if (!PushRule.IsInRange(transform.position, target.transform.position, maxRange))
                return;

            _lastServerPushTime = Time.time;
            var velocity = PushRule.KnockbackVelocity(
                transform.position, target.transform.position, aimDirection,
                _settings.HorizontalSpeed, _settings.UpwardSpeed);
            target.ReceivePush(target.Owner, velocity);
        }

        [TargetRpc]
        private void ReceivePush(NetworkConnection connection, Vector3 velocity)
        {
            _motor.ApplyKnockback(velocity, _settings.ControlLockSeconds);
        }
    }
}
