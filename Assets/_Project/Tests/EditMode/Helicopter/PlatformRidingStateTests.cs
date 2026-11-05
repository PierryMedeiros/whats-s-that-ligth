using NUnit.Framework;
using ProjetoLuz.Helicopter;

namespace ProjetoLuz.Tests.EditMode.Helicopter
{
    public class PlatformRidingStateTests
    {
        private PlatformRidingState _state;
        private int _boardedCount;
        private int _leftCount;

        [SetUp]
        public void SetUp()
        {
            _state = new PlatformRidingState();
            _boardedCount = 0;
            _leftCount = 0;
            _state.Boarded += () => _boardedCount++;
            _state.Left += () => _leftCount++;
        }

        [Test]
        public void NewState_IsNotRiding()
        {
            Assert.That(_state.IsRiding, Is.False);
        }

        [Test]
        public void EnterVolume_BoardsOnce()
        {
            _state.EnterVolume();
            _state.EnterVolume();

            Assert.That(_state.IsRiding, Is.True);
            Assert.That(_boardedCount, Is.EqualTo(1));
        }

        [Test]
        public void ExitVolume_AfterBoarding_Leaves()
        {
            _state.EnterVolume();

            _state.ExitVolume();

            Assert.That(_state.IsRiding, Is.False);
            Assert.That(_leftCount, Is.EqualTo(1));
        }

        [Test]
        public void ExitVolume_WithoutBoarding_DoesNothing()
        {
            _state.ExitVolume();

            Assert.That(_leftCount, Is.EqualTo(0));
        }

        [Test]
        public void SitWhileRiding_Leaves()
        {
            _state.EnterVolume();

            _state.SetSeated(true);

            Assert.That(_state.IsRiding, Is.False);
            Assert.That(_leftCount, Is.EqualTo(1));
        }

        [Test]
        public void EnterVolume_WhileSeated_DoesNotBoard()
        {
            _state.SetSeated(true);

            _state.EnterVolume();

            Assert.That(_state.IsRiding, Is.False);
            Assert.That(_boardedCount, Is.EqualTo(0));
        }

        [Test]
        public void StandUp_DoesNotBoardUntilEnteringAgain()
        {
            _state.EnterVolume();
            _state.SetSeated(true);

            _state.SetSeated(false);

            Assert.That(_state.IsRiding, Is.False);
            Assert.That(_boardedCount, Is.EqualTo(1));

            _state.EnterVolume();

            Assert.That(_state.IsRiding, Is.True);
            Assert.That(_boardedCount, Is.EqualTo(2));
        }
    }
}
