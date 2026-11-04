using NUnit.Framework;
using ProjetoLuz.Player;
using UnityEngine;

namespace ProjetoLuz.Tests.EditMode.Player
{
    public class PushRuleTests
    {
        private const float Tolerance = 0.0001f;

        [Test]
        public void IsCooldownOver_BeforeCooldown_IsFalse()
        {
            Assert.That(PushRule.IsCooldownOver(10f, 10.3f, 0.6f), Is.False);
        }

        [Test]
        public void IsCooldownOver_ExactlyAtCooldown_IsTrue()
        {
            Assert.That(PushRule.IsCooldownOver(10f, 10.5f, 0.5f), Is.True);
        }

        [Test]
        public void IsCooldownOver_FirstPushEver_IsTrue()
        {
            Assert.That(PushRule.IsCooldownOver(float.NegativeInfinity, 0f, 0.6f), Is.True);
        }

        [Test]
        public void IsInRange_WithinRange_IsTrue()
        {
            Assert.That(PushRule.IsInRange(Vector3.zero, new Vector3(1f, 0f, 1f), 2f), Is.True);
        }

        [Test]
        public void IsInRange_BeyondRange_IsFalse()
        {
            Assert.That(PushRule.IsInRange(Vector3.zero, new Vector3(3f, 0f, 0f), 2f), Is.False);
        }

        [Test]
        public void KnockbackVelocity_PointsAwayFromPusher()
        {
            var velocity = PushRule.KnockbackVelocity(Vector3.zero, new Vector3(0f, 0f, 2f), Vector3.right, 9f, 3f);

            Assert.That(Vector3.Distance(velocity, new Vector3(0f, 3f, 9f)), Is.LessThan(Tolerance));
        }

        [Test]
        public void KnockbackVelocity_IgnoresHeightDifferenceForDirection()
        {
            var velocity = PushRule.KnockbackVelocity(Vector3.zero, new Vector3(2f, 5f, 0f), Vector3.forward, 9f, 3f);

            Assert.That(Vector3.Distance(velocity, new Vector3(9f, 3f, 0f)), Is.LessThan(Tolerance));
        }

        [Test]
        public void KnockbackVelocity_SamePosition_UsesFallbackDirection()
        {
            var velocity = PushRule.KnockbackVelocity(Vector3.zero, Vector3.zero, new Vector3(0f, 0.5f, -2f), 9f, 3f);

            Assert.That(Vector3.Distance(velocity, new Vector3(0f, 3f, -9f)), Is.LessThan(Tolerance));
        }

        [Test]
        public void KnockbackVelocity_NegativeSpeeds_AreZero()
        {
            var velocity = PushRule.KnockbackVelocity(Vector3.zero, Vector3.forward, Vector3.forward, -9f, -3f);

            Assert.That(velocity, Is.EqualTo(Vector3.zero));
        }
    }
}
