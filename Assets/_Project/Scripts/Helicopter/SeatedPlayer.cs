using FishNet.Object;
using ProjetoLuz.Player;
using UnityEngine;

namespace ProjetoLuz.Helicopter
{
    public sealed class SeatedPlayer : MonoBehaviour
    {
        [SerializeField] private NetworkObject _networkObject;
        [SerializeField] private Rigidbody _body;
        [SerializeField] private Collider _collider;
        [SerializeField] private PlayerLook _look;
        [SerializeField] private PlayerInputReader _input;
        [SerializeField] private Behaviour[] _disabledWhileSeated;

        public PilotSeat Seat { get; private set; }
        public bool IsSeated => Seat != null;
        public bool IsOwner => _networkObject.IsOwner;
        public PlayerInputReader Input => _input;
        public NetworkObject NetworkObject => _networkObject;

        public void Sit(PilotSeat seat)
        {
            Seat = seat;
            _collider.enabled = false;
            if (!IsOwner)
                return;

            SetOwnerControl(false);
            _body.isKinematic = true;
            _body.interpolation = RigidbodyInterpolation.None;
            var seatYaw = seat.transform.eulerAngles.y;
            _networkObject.SetParent(seat);
            transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            _look.AddYaw(-seatYaw);
        }

        public void Stand(Vector3 exitPosition)
        {
            Seat = null;
            _collider.enabled = true;
            if (!IsOwner)
                return;

            var seatYaw = transform.eulerAngles.y;
            _networkObject.UnsetParent();
            transform.SetPositionAndRotation(exitPosition, Quaternion.identity);
            _body.position = exitPosition;
            _body.rotation = Quaternion.identity;
            _look.AddYaw(seatYaw);
            _body.isKinematic = false;
            _body.interpolation = RigidbodyInterpolation.Interpolate;
            _body.linearVelocity = Vector3.zero;
            SetOwnerControl(true);
        }

        private void SetOwnerControl(bool isEnabled)
        {
            foreach (var behaviour in _disabledWhileSeated)
                behaviour.enabled = isEnabled;
        }
    }
}
