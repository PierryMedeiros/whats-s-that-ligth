using NUnit.Framework;
using ProjetoLuz.Player;

namespace ProjetoLuz.Tests.EditMode.Player
{
    public class JumpRuleTests
    {
        [Test]
        public void CanJump_GroundedAfterCooldown_IsTrue()
        {
            Assert.That(JumpRule.CanJump(true, 0.3f, 0.2f), Is.True);
        }

        [Test]
        public void CanJump_InTheAir_IsFalse()
        {
            Assert.That(JumpRule.CanJump(false, 10f, 0.2f), Is.False);
        }

        [Test]
        public void CanJump_GroundedDuringCooldown_IsFalse()
        {
            Assert.That(JumpRule.CanJump(true, 0.05f, 0.2f), Is.False);
        }

        [Test]
        public void CanJump_ExactlyAtCooldown_IsTrue()
        {
            Assert.That(JumpRule.CanJump(true, 0.2f, 0.2f), Is.True);
        }
    }
}
