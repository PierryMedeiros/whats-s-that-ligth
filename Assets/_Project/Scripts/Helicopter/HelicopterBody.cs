using FishNet.Connection;
using FishNet.Object;
using UnityEngine;

namespace ProjetoLuz.Helicopter
{
    public sealed class HelicopterBody : NetworkBehaviour
    {
        [SerializeField] private Rigidbody _body;

        private Vector3 _pendingVelocity;
        private bool _hasPendingVelocity;

        public Rigidbody Body => _body;
        public bool IsSimulating => IsController;

        public override void OnStartNetwork()
        {
            base.OnStartNetwork();
            ApplySimulation();
        }

        public override void OnOwnershipServer(NetworkConnection prevOwner)
        {
            base.OnOwnershipServer(prevOwner);
            ApplySimulation();
        }

        public override void OnOwnershipClient(NetworkConnection prevOwner)
        {
            base.OnOwnershipClient(prevOwner);
            ApplySimulation();
        }

        [Server]
        public void HandOver(NetworkConnection newOwner)
        {
            var velocity = _body.linearVelocity;
            GiveOwnership(newOwner);
            if (newOwner.IsLocalClient)
                return;

            ReceiveHandOver(newOwner, velocity);
        }

        [Server]
        public void TakeBack(Vector3 velocity)
        {
            RemoveOwnership();
            _body.linearVelocity = velocity;
        }

        [TargetRpc]
        private void ReceiveHandOver(NetworkConnection connection, Vector3 velocity)
        {
            _pendingVelocity = velocity;
            _hasPendingVelocity = true;
            ApplySimulation();
        }

        private void ApplySimulation()
        {
            var isSimulating = IsSimulating;
            _body.isKinematic = !isSimulating;
            _body.interpolation = isSimulating ? RigidbodyInterpolation.Interpolate : RigidbodyInterpolation.None;
            if (!isSimulating || !_hasPendingVelocity)
                return;

            _body.linearVelocity = _pendingVelocity;
            _hasPendingVelocity = false;
        }
    }
}
