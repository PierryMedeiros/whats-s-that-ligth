using FishNet.Object;
using UnityEngine;

namespace ProjetoLuz.Helicopter
{
    public sealed class PlatformRider : MonoBehaviour
    {
        [SerializeField] private NetworkObject _networkObject;
        [SerializeField] private Rigidbody _body;
        [SerializeField] private SeatedPlayer _seated;

        private readonly PlatformRidingState _state = new();

        private HelicopterPlatform _platform;

        private void OnEnable()
        {
            _state.Boarded += Board;
            _state.Left += Leave;
            _seated.SeatedChanged += _state.SetSeated;
        }

        private void OnDisable()
        {
            _state.Boarded -= Board;
            _state.Left -= Leave;
            _seated.SeatedChanged -= _state.SetSeated;
        }

        // A dynamic child Rigidbody does not follow a parent moved by physics, so the simulated platform motion is
        // applied by hand. A kinematic platform moved by its NetworkTransform already carries the child.
        private void FixedUpdate()
        {
            if (!_state.IsRiding || _body.isKinematic)
                return;

            var deltaTime = Time.fixedDeltaTime;
            _body.position = PlatformVelocity.Carry(
                _body.position, _platform.SimulatedPointVelocity(_body.position), deltaTime);
            var yawDegrees = _platform.SimulatedYawRateDegrees() * deltaTime;
            _body.rotation = Quaternion.Euler(0f, yawDegrees, 0f) * _body.rotation;
        }

        // Unity sends trigger messages to disabled behaviours too, and this one is enabled only on the owner.
        private void OnTriggerEnter(Collider other)
        {
            if (!enabled || !other.TryGetComponent(out HelicopterPlatform platform))
                return;

            _platform = platform;
            _state.EnterVolume();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!enabled || _platform == null || other.gameObject != _platform.gameObject)
                return;

            _state.ExitVolume();
        }

        private void Board()
        {
            _body.interpolation = RigidbodyInterpolation.None;
            if (!_body.isKinematic)
                _body.linearVelocity = PlatformVelocity.ToRelative(_body.linearVelocity, _platform.Velocity);

            _networkObject.SetParent(_platform);
        }

        private void Leave()
        {
            var platformVelocity = _platform != null ? _platform.Velocity : Vector3.zero;
            if (_platform != null && transform.parent == _platform.transform)
                _networkObject.UnsetParent();

            _body.interpolation = RigidbodyInterpolation.Interpolate;
            if (!_body.isKinematic)
                _body.linearVelocity = PlatformVelocity.ToWorld(_body.linearVelocity, platformVelocity);
        }
    }
}
