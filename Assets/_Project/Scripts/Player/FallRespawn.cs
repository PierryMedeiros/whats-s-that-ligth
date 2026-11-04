using ProjetoLuz.Islands;
using UnityEngine;

namespace ProjetoLuz.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class FallRespawn : MonoBehaviour
    {
        [SerializeField] private Totem _totem;
        [SerializeField] private float _killHeight = -30f;
        [SerializeField, Min(0f)] private float _respawnDelay = 3f;

        private readonly FallRespawnState _state = new();

        private Rigidbody _body;

        public float RespawnDelay => _respawnDelay;

        private void Awake()
        {
            _body = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            _state.Fell += Freeze;
            _state.Respawned += RespawnAtTotem;
        }

        private void OnDisable()
        {
            _state.Fell -= Freeze;
            _state.Respawned -= RespawnAtTotem;
        }

        private void FixedUpdate()
        {
            _state.Tick(_body.position.y, _killHeight, _respawnDelay, Time.fixedDeltaTime);
        }

        private void Freeze()
        {
            _body.linearVelocity = Vector3.zero;
            _body.angularVelocity = Vector3.zero;
            _body.isKinematic = true;
        }

        private void RespawnAtTotem()
        {
            var position = _totem.SpawnPosition;
            _body.position = position;
            transform.position = position;
            _body.isKinematic = false;
            _body.linearVelocity = Vector3.zero;
        }
    }
}
