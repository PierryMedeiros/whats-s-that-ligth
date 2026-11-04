using UnityEngine;

namespace ProjetoLuz.Player
{
    public sealed class LookState
    {
        private readonly float _pitchLimit;

        public float Yaw { get; private set; }
        public float Pitch { get; private set; }

        public LookState(float pitchLimit, float initialYaw)
        {
            _pitchLimit = Mathf.Abs(pitchLimit);
            Yaw = Mathf.Repeat(initialYaw, 360f);
        }

        public void ApplyDelta(Vector2 delta, float sensitivity)
        {
            Rotate(delta * sensitivity);
        }

        public void ApplyRate(Vector2 rate, float degreesPerSecond, float deltaTime)
        {
            Rotate(rate * (degreesPerSecond * deltaTime));
        }

        private void Rotate(Vector2 degrees)
        {
            Yaw = Mathf.Repeat(Yaw + degrees.x, 360f);
            Pitch = Mathf.Clamp(Pitch - degrees.y, -_pitchLimit, _pitchLimit);
        }
    }
}
