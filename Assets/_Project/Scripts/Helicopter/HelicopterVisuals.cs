using UnityEngine;

namespace ProjetoLuz.Helicopter
{
    public sealed class HelicopterVisuals : MonoBehaviour
    {
        [SerializeField] private PilotSeat _seat;
        [SerializeField] private Transform _tiltPivot;
        [SerializeField] private Transform _mainRotor;
        [SerializeField] private Transform _tailRotor;
        [SerializeField] private HelicopterSettings _flightSettings;
        [SerializeField] private HelicopterVisualSettings _settings;

        private Vector3 _lastPosition;
        private float _lastYaw;
        private float _forwardSpeed;
        private float _forwardAcceleration;
        private float _yawRate;
        private float _pitch;
        private float _roll;
        private float _rotorSpeed;
        private bool _isEngineOn;

        private void OnEnable()
        {
            _lastPosition = transform.position;
            _lastYaw = transform.eulerAngles.y;
            _isEngineOn = _seat.IsOccupied;
            _seat.OccupiedChanged += SetEngine;
        }

        private void OnDisable()
        {
            _seat.OccupiedChanged -= SetEngine;
        }

        private void SetEngine(bool isOn)
        {
            _isEngineOn = isOn;
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            if (deltaTime <= 0f)
                return;

            TrackMotion(deltaTime);
            Tilt(deltaTime);
            SpinRotors(deltaTime);
        }

        private void TrackMotion(float deltaTime)
        {
            var position = transform.position;
            var yaw = transform.eulerAngles.y;
            var forwardSpeed = Vector3.Dot(position - _lastPosition, transform.forward) / deltaTime;
            var yawRate = Mathf.DeltaAngle(_lastYaw, yaw) / deltaTime;
            _lastPosition = position;
            _lastYaw = yaw;

            var sharpness = _settings.MotionSharpness;
            var smoothedSpeed = HelicopterTilt.Smooth(_forwardSpeed, forwardSpeed, sharpness, deltaTime);
            var acceleration = (smoothedSpeed - _forwardSpeed) / deltaTime;
            _forwardSpeed = smoothedSpeed;
            _forwardAcceleration = HelicopterTilt.Smooth(_forwardAcceleration, acceleration, sharpness, deltaTime);
            _yawRate = HelicopterTilt.Smooth(_yawRate, yawRate, sharpness, deltaTime);
        }

        private void Tilt(float deltaTime)
        {
            var targetPitch = HelicopterTilt.Pitch(
                HelicopterTilt.Fraction(_forwardSpeed, _flightSettings.MaxForwardSpeed),
                HelicopterTilt.Fraction(_forwardAcceleration, _flightSettings.HorizontalAcceleration),
                _settings.PitchAtFullSpeed, _settings.PitchAtFullAcceleration, _settings.MaxPitch);
            var targetRoll = HelicopterTilt.Roll(
                HelicopterTilt.Fraction(_yawRate, _flightSettings.MaxYawRate), _settings.RollAtFullYaw);

            _pitch = HelicopterTilt.Smooth(_pitch, targetPitch, _settings.TiltSharpness, deltaTime);
            _roll = HelicopterTilt.Smooth(_roll, targetRoll, _settings.TiltSharpness, deltaTime);
            _tiltPivot.localRotation = Quaternion.Euler(_pitch, 0f, _roll);
        }

        private void SpinRotors(float deltaTime)
        {
            _rotorSpeed = RotorSpin.Step(
                _rotorSpeed, _isEngineOn, _settings.RotorMaxSpeed,
                _settings.RotorSpinUpRate, _settings.RotorSpinDownRate, deltaTime);
            _mainRotor.Rotate(0f, _rotorSpeed * deltaTime, 0f, Space.Self);
            _tailRotor.Rotate(_rotorSpeed * _settings.TailRotorSpeedMultiplier * deltaTime, 0f, 0f, Space.Self);
        }
    }
}
