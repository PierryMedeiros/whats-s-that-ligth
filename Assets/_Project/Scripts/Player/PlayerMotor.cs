using UnityEngine;

namespace ProjetoLuz.Player
{
    [RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
    public sealed class PlayerMotor : MonoBehaviour
    {
        private const float GroundCastRadiusScale = 0.95f;

        [SerializeField] private PlayerInputReader _input;
        [SerializeField] private PlayerLook _look;
        [SerializeField] private MovementSettings _settings;

        private readonly RaycastHit[] _groundHits = new RaycastHit[8];

        private Rigidbody _body;
        private CapsuleCollider _capsule;
        private bool _hasGroundContact;
        private Vector3 _groundNormal = Vector3.up;
        private bool _hasSteepContact;
        private Vector3 _steepNormal = Vector3.up;
        private bool _jumpRequested;
        private float _secondsSinceJump = float.MaxValue;

        private bool IsGrounded => _hasGroundContact && _secondsSinceJump >= _settings.JumpCooldown;

        private void Awake()
        {
            _body = GetComponent<Rigidbody>();
            _capsule = GetComponent<CapsuleCollider>();
        }

        private void OnEnable()
        {
            _input.JumpPressed += RequestJump;
        }

        private void OnDisable()
        {
            _input.JumpPressed -= RequestJump;
        }

        private void FixedUpdate()
        {
            var deltaTime = Time.fixedDeltaTime;
            _secondsSinceJump += deltaTime;

            if (!_body.isKinematic)
                Simulate(deltaTime);

            _jumpRequested = false;
        }

        private void RequestJump()
        {
            _jumpRequested = true;
        }

        private void Simulate(float deltaTime)
        {
            DetectGround();
            Move(deltaTime);
            TryJump();
        }

        private void DetectGround()
        {
            var radius = _capsule.radius * GroundCastRadiusScale;
            var origin = transform.TransformPoint(_capsule.center);
            var distance = _capsule.height * 0.5f - radius + _settings.GroundCheckDistance;
            var hitCount = Physics.SphereCastNonAlloc(
                origin, radius, Vector3.down, _groundHits, distance, Physics.AllLayers, QueryTriggerInteraction.Ignore);

            _hasGroundContact = false;
            _groundNormal = Vector3.up;
            _hasSteepContact = false;
            _steepNormal = Vector3.up;
            for (var i = 0; i < hitCount; i++)
                ConsiderGroundHit(_groundHits[i]);
        }

        private void ConsiderGroundHit(RaycastHit hit)
        {
            if (hit.collider == _capsule || hit.distance <= 0f)
                return;

            if (GroundRule.IsWalkable(hit.normal, _settings.MaxSlopeAngle))
            {
                _hasGroundContact = true;
                _groundNormal = hit.normal;
                return;
            }

            _hasSteepContact = true;
            _steepNormal = hit.normal;
        }

        private void Move(float deltaTime)
        {
            var speed = _input.IsSprinting ? _settings.SprintSpeed : _settings.WalkSpeed;
            var flatTarget = GroundMovement.TargetVelocity(_input.Move, _look.Yaw, speed);
            if (_hasSteepContact)
                flatTarget = GroundMovement.BlockIntoSteepSurface(flatTarget, _steepNormal);

            if (IsGrounded)
                MoveOnGround(flatTarget, deltaTime);
            else
                MoveInAir(flatTarget, deltaTime);
        }

        private void MoveOnGround(Vector3 flatTarget, float deltaTime)
        {
            var slopeTarget = Vector3.ProjectOnPlane(flatTarget, _groundNormal).normalized * flatTarget.magnitude;
            _body.linearVelocity = GroundMovement.Accelerate(
                _body.linearVelocity, slopeTarget, _settings.GroundAcceleration, deltaTime);

            var gravityAlongSlope = Vector3.ProjectOnPlane(Physics.gravity, _groundNormal);
            _body.AddForce(-gravityAlongSlope, ForceMode.Acceleration);
        }

        private void MoveInAir(Vector3 flatTarget, float deltaTime)
        {
            var velocity = _body.linearVelocity;
            var horizontal = new Vector3(velocity.x, 0f, velocity.z);
            var newHorizontal = GroundMovement.Accelerate(horizontal, flatTarget, _settings.AirAcceleration, deltaTime);
            _body.linearVelocity = new Vector3(newHorizontal.x, velocity.y, newHorizontal.z);
        }

        private void TryJump()
        {
            if (!_jumpRequested)
                return;

            if (!JumpRule.CanJump(_hasGroundContact, _secondsSinceJump, _settings.JumpCooldown))
                return;

            var velocity = _body.linearVelocity;
            velocity.y = JumpMath.VelocityForHeight(_settings.JumpHeight, Physics.gravity.magnitude);
            _body.linearVelocity = velocity;
            _secondsSinceJump = 0f;
        }
    }
}
