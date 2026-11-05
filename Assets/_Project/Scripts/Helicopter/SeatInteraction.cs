using ProjetoLuz.Player;
using UnityEngine;

namespace ProjetoLuz.Helicopter
{
    public sealed class SeatInteraction : MonoBehaviour
    {
        [SerializeField] private PlayerInputReader _input;
        [SerializeField] private SeatedPlayer _seated;
        [SerializeField] private Transform _aim;
        [SerializeField, Min(0f)] private float _range = 3f;

        private void OnEnable()
        {
            _input.InteractPressed += Interact;
        }

        private void OnDisable()
        {
            _input.InteractPressed -= Interact;
        }

        private void Interact()
        {
            if (_seated.IsSeated)
            {
                _seated.Seat.RequestExit();
                return;
            }

            if (!Physics.Raycast(_aim.position, _aim.forward, out var hit, _range, Physics.AllLayers, QueryTriggerInteraction.Collide))
                return;

            if (hit.collider.TryGetComponent(out PilotSeat seat))
                seat.RequestEnter(_seated.NetworkObject);
        }
    }
}
