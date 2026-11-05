using UnityEngine;

namespace ProjetoLuz.Helicopter
{
    public sealed class HelicopterFallReset : MonoBehaviour
    {
        [SerializeField] private HelicopterBody _helicopter;
        [SerializeField] private float _killHeight = -40f;

        private Vector3 _landingPosition;
        private Quaternion _landingRotation;

        private void Awake()
        {
            _landingPosition = transform.position;
            _landingRotation = transform.rotation;
        }

        private void FixedUpdate()
        {
            if (!_helicopter.IsSimulating || _helicopter.Body.position.y >= _killHeight)
                return;

            var body = _helicopter.Body;
            body.linearVelocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;
            body.position = _landingPosition;
            body.rotation = _landingRotation;
            transform.SetPositionAndRotation(_landingPosition, _landingRotation);
        }
    }
}
