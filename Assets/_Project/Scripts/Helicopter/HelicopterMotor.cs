using ProjetoLuz.Player;
using UnityEngine;

namespace ProjetoLuz.Helicopter
{
    public sealed class HelicopterMotor : MonoBehaviour
    {
        [SerializeField] private HelicopterBody _helicopter;
        [SerializeField] private PilotSeat _seat;
        [SerializeField] private HelicopterSettings _settings;

        private PlayerInputReader _pilotInput;
        private bool _isEngineOn;
        private float _yawRate;

        private void OnEnable()
        {
            _isEngineOn = _seat.IsOccupied;
            _seat.OccupiedChanged += SetEngine;
        }

        private void OnDisable()
        {
            _seat.OccupiedChanged -= SetEngine;
        }

        public void SetPilotInput(PlayerInputReader input)
        {
            _pilotInput = input;
        }

        private void SetEngine(bool isOn)
        {
            _isEngineOn = isOn;
        }

        private void FixedUpdate()
        {
            if (!_helicopter.IsSimulating)
            {
                _yawRate = 0f;
                return;
            }

            var body = _helicopter.Body;
            body.useGravity = !_isEngineOn;
            if (_isEngineOn)
                Fly(body, Time.fixedDeltaTime);
        }

        private void Fly(Rigidbody body, float deltaTime)
        {
            var move = _pilotInput != null ? _pilotInput.Move : Vector2.zero;
            var lift = LiftInput();

            _yawRate = HelicopterFlight.YawRate(
                _yawRate, move.x, _settings.MaxYawRate, _settings.YawAcceleration, deltaTime);
            var target = HelicopterFlight.TargetVelocity(
                move.y, lift, body.rotation.eulerAngles.y, _settings.MaxForwardSpeed, _settings.MaxVerticalSpeed);

            body.linearVelocity = HelicopterFlight.Accelerate(
                body.linearVelocity, target, _settings.HorizontalAcceleration, _settings.VerticalAcceleration, deltaTime);
            body.angularVelocity = new Vector3(0f, _yawRate * Mathf.Deg2Rad, 0f);
        }

        private float LiftInput()
        {
            if (_pilotInput == null)
                return 0f;

            var up = _pilotInput.IsJumpHeld ? 1f : 0f;
            var down = _pilotInput.IsCrouchHeld ? 1f : 0f;
            return up - down;
        }
    }
}
