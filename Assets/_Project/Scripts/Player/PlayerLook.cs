using UnityEngine;

namespace ProjetoLuz.Player
{
    public sealed class PlayerLook : MonoBehaviour
    {
        [SerializeField] private PlayerInputReader _input;
        [SerializeField] private LookSettings _settings;
        [SerializeField] private Transform _cameraPivot;

        private LookState _state;

        public float Yaw => _state.Yaw;

        private void Awake()
        {
            _state = new LookState(_settings.PitchLimit, _cameraPivot.eulerAngles.y);
        }

        private void Update()
        {
            ApplyInput();
            _cameraPivot.rotation = Quaternion.Euler(_state.Pitch, _state.Yaw, 0f);
        }

        private void ApplyInput()
        {
            if (!_input.IsLookFromPointer)
            {
                _state.ApplyRate(_input.Look, _settings.GamepadDegreesPerSecond, Time.deltaTime);
                return;
            }

            if (Cursor.lockState != CursorLockMode.Locked)
                return;

            _state.ApplyDelta(_input.Look, _settings.MouseDegreesPerPixel);
        }
    }
}
