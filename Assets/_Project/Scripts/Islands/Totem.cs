using UnityEngine;

namespace ProjetoLuz.Islands
{
    public sealed class Totem : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;

        public Vector3 SpawnPosition => _spawnPoint.position;
    }
}
