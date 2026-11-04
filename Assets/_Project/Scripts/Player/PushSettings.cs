using UnityEngine;

namespace ProjetoLuz.Player
{
    [CreateAssetMenu(menuName = "Projeto Luz/Player/Push Settings")]
    public sealed class PushSettings : ScriptableObject
    {
        [SerializeField, Min(0f)] private float _range = 1.8f;
        [SerializeField, Min(0f)] private float _aimRadius = 0.4f;
        [SerializeField, Min(0f)] private float _serverRangeTolerance = 1f;
        [SerializeField, Min(0f)] private float _horizontalSpeed = 9f;
        [SerializeField, Min(0f)] private float _upwardSpeed = 3f;
        [SerializeField, Min(0f)] private float _cooldown = 0.6f;
        [SerializeField, Min(0f)] private float _controlLockSeconds = 0.5f;

        public float Range => _range;
        public float AimRadius => _aimRadius;
        public float ServerRangeTolerance => _serverRangeTolerance;
        public float HorizontalSpeed => _horizontalSpeed;
        public float UpwardSpeed => _upwardSpeed;
        public float Cooldown => _cooldown;
        public float ControlLockSeconds => _controlLockSeconds;
    }
}
