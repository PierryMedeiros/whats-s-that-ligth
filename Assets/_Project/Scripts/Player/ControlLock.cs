using UnityEngine;

namespace ProjetoLuz.Player
{
    public sealed class ControlLock
    {
        private float _secondsRemaining;

        public bool IsLocked => _secondsRemaining > 0f;

        public void Lock(float seconds)
        {
            _secondsRemaining = Mathf.Max(_secondsRemaining, seconds);
        }

        public void Tick(float deltaTime)
        {
            _secondsRemaining = Mathf.Max(0f, _secondsRemaining - deltaTime);
        }
    }
}
