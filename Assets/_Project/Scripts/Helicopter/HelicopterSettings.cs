using UnityEngine;

namespace ProjetoLuz.Helicopter
{
    [CreateAssetMenu(menuName = "Projeto Luz/Helicopter/Helicopter Settings")]
    public sealed class HelicopterSettings : ScriptableObject
    {
        [SerializeField, Min(0f)] private float _maxForwardSpeed = 18f;
        [SerializeField, Min(0f)] private float _maxVerticalSpeed = 6f;
        [SerializeField, Min(0f)] private float _horizontalAcceleration = 8f;
        [SerializeField, Min(0f)] private float _verticalAcceleration = 10f;
        [SerializeField, Min(0f)] private float _maxYawRate = 70f;
        [SerializeField, Min(0f)] private float _yawAcceleration = 180f;

        public float MaxForwardSpeed => _maxForwardSpeed;
        public float MaxVerticalSpeed => _maxVerticalSpeed;
        public float HorizontalAcceleration => _horizontalAcceleration;
        public float VerticalAcceleration => _verticalAcceleration;
        public float MaxYawRate => _maxYawRate;
        public float YawAcceleration => _yawAcceleration;
    }
}
