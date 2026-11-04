using UnityEngine;

namespace ProjetoLuz.Player
{
    [CreateAssetMenu(menuName = "Projeto Luz/Player/Movement Settings")]
    public sealed class MovementSettings : ScriptableObject
    {
        [SerializeField, Min(0f)] private float _walkSpeed = 5f;
        [SerializeField, Min(0f)] private float _sprintSpeed = 8f;
        [SerializeField, Min(0f)] private float _groundAcceleration = 60f;
        [SerializeField, Min(0f)] private float _airAcceleration = 15f;
        [SerializeField, Min(0f)] private float _jumpHeight = 1.2f;
        [SerializeField, Min(0f)] private float _jumpCooldown = 0.2f;
        [SerializeField, Range(0f, 89f)] private float _maxSlopeAngle = 45f;
        [SerializeField, Min(0f)] private float _groundCheckDistance = 0.15f;

        public float WalkSpeed => _walkSpeed;
        public float SprintSpeed => _sprintSpeed;
        public float GroundAcceleration => _groundAcceleration;
        public float AirAcceleration => _airAcceleration;
        public float JumpHeight => _jumpHeight;
        public float JumpCooldown => _jumpCooldown;
        public float MaxSlopeAngle => _maxSlopeAngle;
        public float GroundCheckDistance => _groundCheckDistance;
    }
}
