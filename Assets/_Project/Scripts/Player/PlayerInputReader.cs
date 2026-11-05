using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjetoLuz.Player
{
    public sealed class PlayerInputReader : MonoBehaviour
    {
        [SerializeField] private InputActionReference _move;
        [SerializeField] private InputActionReference _look;
        [SerializeField] private InputActionReference _jump;
        [SerializeField] private InputActionReference _sprint;
        [SerializeField] private InputActionReference _push;
        [SerializeField] private InputActionReference _interact;
        [SerializeField] private InputActionReference _crouch;

        public event Action JumpPressed;
        public event Action PushPressed;
        public event Action InteractPressed;

        public Vector2 Move => _move.action.ReadValue<Vector2>();
        public Vector2 Look => _look.action.ReadValue<Vector2>();
        public bool IsLookFromPointer => _look.action.activeControl?.device is Pointer;
        public bool IsSprinting => _sprint.action.IsPressed();
        public bool IsJumpHeld => _jump.action.IsPressed();
        public bool IsCrouchHeld => _crouch.action.IsPressed();

        private void OnEnable()
        {
            // The actions belong to a shared asset; disabling them in OnDisable would cut input for any other reader.
            _move.action.Enable();
            _look.action.Enable();
            _jump.action.Enable();
            _sprint.action.Enable();
            _push.action.Enable();
            _interact.action.Enable();
            _crouch.action.Enable();
            _jump.action.performed += OnJumpPerformed;
            _push.action.performed += OnPushPerformed;
            _interact.action.performed += OnInteractPerformed;
        }

        private void OnDisable()
        {
            _jump.action.performed -= OnJumpPerformed;
            _push.action.performed -= OnPushPerformed;
            _interact.action.performed -= OnInteractPerformed;
        }

        private void OnJumpPerformed(InputAction.CallbackContext context)
        {
            JumpPressed?.Invoke();
        }

        private void OnPushPerformed(InputAction.CallbackContext context)
        {
            PushPressed?.Invoke();
        }

        private void OnInteractPerformed(InputAction.CallbackContext context)
        {
            InteractPressed?.Invoke();
        }
    }
}
