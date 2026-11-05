using FishNet.Object;
using UnityEngine;

namespace ProjetoLuz.Helicopter
{
    public sealed class HelicopterPlatform : NetworkBehaviour
    {
        [SerializeField] private Rigidbody _body;
        [SerializeField, Min(0f)] private float _velocitySharpness = 10f;

        private Vector3 _lastPosition;

        public Vector3 Velocity { get; private set; }

        private void OnEnable()
        {
            _lastPosition = transform.position;
            Velocity = Vector3.zero;
        }

        private void Update()
        {
            var position = transform.position;
            Velocity = PlatformVelocity.Track(Velocity, _lastPosition, position, _velocitySharpness, Time.deltaTime);
            _lastPosition = position;
        }

        public Vector3 SimulatedPointVelocity(Vector3 worldPoint)
        {
            return _body.isKinematic ? Vector3.zero : _body.GetPointVelocity(worldPoint);
        }

        public float SimulatedYawRateDegrees()
        {
            return _body.isKinematic ? 0f : _body.angularVelocity.y * Mathf.Rad2Deg;
        }
    }
}
