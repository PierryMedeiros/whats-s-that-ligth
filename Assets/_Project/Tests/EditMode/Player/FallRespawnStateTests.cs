using NUnit.Framework;
using ProjetoLuz.Player;

namespace ProjetoLuz.Tests.EditMode.Player
{
    public class FallRespawnStateTests
    {
        private const float KillHeight = -20f;
        private const float Delay = 3f;

        private FallRespawnState _state;
        private int _fellCount;
        private int _respawnedCount;

        [SetUp]
        public void SetUp()
        {
            _state = new FallRespawnState();
            _fellCount = 0;
            _respawnedCount = 0;
            _state.Fell += () => _fellCount++;
            _state.Respawned += () => _respawnedCount++;
        }

        [Test]
        public void Tick_AboveKillHeight_DoesNotFall()
        {
            _state.Tick(0f, KillHeight, Delay, 0.02f);

            Assert.That(_state.IsFallen, Is.False);
            Assert.That(_fellCount, Is.EqualTo(0));
        }

        [Test]
        public void Tick_ExactlyAtKillHeight_DoesNotFall()
        {
            _state.Tick(KillHeight, KillHeight, Delay, 0.02f);

            Assert.That(_state.IsFallen, Is.False);
        }

        [Test]
        public void Tick_StayingBelowKillHeight_FallsOnlyOnce()
        {
            _state.Tick(-21f, KillHeight, Delay, 0.02f);
            _state.Tick(-30f, KillHeight, Delay, 0.02f);
            _state.Tick(-40f, KillHeight, Delay, 0.02f);

            Assert.That(_state.IsFallen, Is.True);
            Assert.That(_fellCount, Is.EqualTo(1));
        }

        [Test]
        public void Tick_BeforeDelayEnds_DoesNotRespawn()
        {
            _state.Tick(-21f, KillHeight, Delay, 0.02f);
            _state.Tick(-21f, KillHeight, Delay, 2.9f);

            Assert.That(_respawnedCount, Is.EqualTo(0));
        }

        [Test]
        public void Tick_AfterDelay_RespawnsOnce()
        {
            _state.Tick(-21f, KillHeight, Delay, 0.02f);
            _state.Tick(-21f, KillHeight, Delay, 3f);

            Assert.That(_state.IsFallen, Is.False);
            Assert.That(_respawnedCount, Is.EqualTo(1));
        }

        [Test]
        public void Tick_AfterRespawnAtSafeHeight_StaysUp()
        {
            _state.Tick(-21f, KillHeight, Delay, 0.02f);
            _state.Tick(-21f, KillHeight, Delay, 3f);
            _state.Tick(5f, KillHeight, Delay, 0.02f);

            Assert.That(_state.IsFallen, Is.False);
            Assert.That(_fellCount, Is.EqualTo(1));
            Assert.That(_respawnedCount, Is.EqualTo(1));
        }

        [Test]
        public void Tick_FallingAgainAfterRespawn_StartsNewCycle()
        {
            _state.Tick(-21f, KillHeight, Delay, 0.02f);
            _state.Tick(-21f, KillHeight, Delay, 3f);
            _state.Tick(-21f, KillHeight, Delay, 0.02f);

            Assert.That(_state.IsFallen, Is.True);
            Assert.That(_fellCount, Is.EqualTo(2));
        }

        [Test]
        public void Tick_ZeroDelay_RespawnsOnNextTick()
        {
            _state.Tick(-21f, KillHeight, 0f, 0.02f);
            _state.Tick(-21f, KillHeight, 0f, 0.02f);

            Assert.That(_respawnedCount, Is.EqualTo(1));
        }
    }
}
