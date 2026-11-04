using FishNet.Object;
using UnityEngine;

namespace ProjetoLuz.Player
{
    public sealed class PlayerOwnership : NetworkBehaviour
    {
        [SerializeField] private Behaviour[] _ownerOnlyBehaviours;
        [SerializeField] private Rigidbody _body;

        public override void OnStartClient()
        {
            base.OnStartClient();
            ApplyOwnership(IsOwner);
        }

        private void ApplyOwnership(bool isOwner)
        {
            foreach (var behaviour in _ownerOnlyBehaviours)
                behaviour.enabled = isOwner;

            _body.isKinematic = !isOwner;
            _body.interpolation = isOwner ? RigidbodyInterpolation.Interpolate : RigidbodyInterpolation.None;
        }
    }
}
