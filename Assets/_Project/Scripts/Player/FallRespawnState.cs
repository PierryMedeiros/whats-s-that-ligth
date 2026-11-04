using System;

namespace ProjetoLuz.Player
{
    public sealed class FallRespawnState
    {
        private float _secondsUntilRespawn;

        public event Action Fell;
        public event Action Respawned;

        public bool IsFallen { get; private set; }

        public void Tick(float height, float killHeight, float respawnDelay, float deltaTime)
        {
            if (!IsFallen)
            {
                DetectFall(height, killHeight, respawnDelay);
                return;
            }

            _secondsUntilRespawn -= deltaTime;
            if (_secondsUntilRespawn > 0f)
                return;

            IsFallen = false;
            Respawned?.Invoke();
        }

        private void DetectFall(float height, float killHeight, float respawnDelay)
        {
            if (height >= killHeight)
                return;

            IsFallen = true;
            _secondsUntilRespawn = respawnDelay;
            Fell?.Invoke();
        }
    }
}
