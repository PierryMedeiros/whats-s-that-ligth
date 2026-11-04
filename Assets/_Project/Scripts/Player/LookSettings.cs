using UnityEngine;

namespace ProjetoLuz.Player
{
    [CreateAssetMenu(menuName = "Projeto Luz/Player/Look Settings")]
    public sealed class LookSettings : ScriptableObject
    {
        [SerializeField, Min(0f)] private float _mouseDegreesPerPixel = 0.1f;
        [SerializeField, Min(0f)] private float _gamepadDegreesPerSecond = 180f;
        [SerializeField, Range(0f, 89f)] private float _pitchLimit = 85f;

        public float MouseDegreesPerPixel => _mouseDegreesPerPixel;
        public float GamepadDegreesPerSecond => _gamepadDegreesPerSecond;
        public float PitchLimit => _pitchLimit;
    }
}
