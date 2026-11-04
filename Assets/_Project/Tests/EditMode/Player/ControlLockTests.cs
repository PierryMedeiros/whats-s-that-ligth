using NUnit.Framework;
using ProjetoLuz.Player;

namespace ProjetoLuz.Tests.EditMode.Player
{
    public class ControlLockTests
    {
        [Test]
        public void NewLock_IsUnlocked()
        {
            Assert.That(new ControlLock().IsLocked, Is.False);
        }

        [Test]
        public void Lock_IsLockedUntilTimePasses()
        {
            var controlLock = new ControlLock();

            controlLock.Lock(0.5f);
            controlLock.Tick(0.4f);
            Assert.That(controlLock.IsLocked, Is.True);

            controlLock.Tick(0.1f);
            Assert.That(controlLock.IsLocked, Is.False);
        }

        [Test]
        public void Lock_ShorterLockDoesNotCutLongerOne()
        {
            var controlLock = new ControlLock();

            controlLock.Lock(1f);
            controlLock.Lock(0.1f);
            controlLock.Tick(0.5f);

            Assert.That(controlLock.IsLocked, Is.True);
        }

        [Test]
        public void Lock_ZeroOrNegative_StaysUnlocked()
        {
            var controlLock = new ControlLock();

            controlLock.Lock(0f);
            controlLock.Lock(-1f);

            Assert.That(controlLock.IsLocked, Is.False);
        }

        [Test]
        public void Tick_LongAfterUnlock_StaysUnlocked()
        {
            var controlLock = new ControlLock();

            controlLock.Lock(0.2f);
            controlLock.Tick(10f);
            controlLock.Lock(0.1f);

            Assert.That(controlLock.IsLocked, Is.True);
        }
    }
}
