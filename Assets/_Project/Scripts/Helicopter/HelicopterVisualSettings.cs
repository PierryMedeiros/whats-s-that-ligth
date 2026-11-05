using UnityEngine;

namespace ProjetoLuz.Helicopter
{
    [CreateAssetMenu(menuName = "Projeto Luz/Helicopter/Helicopter Visual Settings")]
    public sealed class HelicopterVisualSettings : ScriptableObject
    {
        [SerializeField] private float _pitchAtFullSpeed = 8f;
        [SerializeField] private float _pitchAtFullAcceleration = 10f;
        [SerializeField, Min(0f)] private float _maxPitch = 15f;
        [SerializeField] private float _rollAtFullYaw = 12f;
        [SerializeField, Min(0f)] private float _tiltSharpness = 4f;
        [SerializeField, Min(0f)] private float _motionSharpness = 8f;
        [SerializeField, Min(0f)] private float _rotorMaxSpeed = 1080f;
        [SerializeField, Min(0f)] private float _rotorSpinUpRate = 540f;
        [SerializeField, Min(0f)] private float _rotorSpinDownRate = 270f;
        [SerializeField, Min(0f)] private float _tailRotorSpeedMultiplier = 2f;

        public float PitchAtFullSpeed => _pitchAtFullSpeed;
        public float PitchAtFullAcceleration => _pitchAtFullAcceleration;
        public float MaxPitch => _maxPitch;
        public float RollAtFullYaw => _rollAtFullYaw;
        public float TiltSharpness => _tiltSharpness;
        public float MotionSharpness => _motionSharpness;
        public float RotorMaxSpeed => _rotorMaxSpeed;
        public float RotorSpinUpRate => _rotorSpinUpRate;
        public float RotorSpinDownRate => _rotorSpinDownRate;
        public float TailRotorSpeedMultiplier => _tailRotorSpeedMultiplier;
    }
}
