using System;

namespace ProjetoLuz.Helicopter
{
    public sealed class PlatformRidingState
    {
        private bool _isInsideVolume;
        private bool _isSeated;

        public event Action Boarded;
        public event Action Left;

        public bool IsRiding { get; private set; }

        public void EnterVolume()
        {
            if (_isSeated)
                return;

            _isInsideVolume = true;
            Refresh();
        }

        public void ExitVolume()
        {
            _isInsideVolume = false;
            Refresh();
        }

        public void SetSeated(bool isSeated)
        {
            _isSeated = isSeated;
            if (isSeated)
                _isInsideVolume = false;

            Refresh();
        }

        private void Refresh()
        {
            var shouldRide = _isInsideVolume && !_isSeated;
            if (shouldRide == IsRiding)
                return;

            IsRiding = shouldRide;
            if (shouldRide)
                Boarded?.Invoke();
            else
                Left?.Invoke();
        }
    }
}
