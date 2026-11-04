using NUnit.Framework;
using ProjetoLuz.Player;

namespace ProjetoLuz.Tests.EditMode.Player
{
    public class JumpMathTests
    {
        [Test]
        public void VelocityForHeight_ReachesRequestedHeight()
        {
            const float gravity = 9.81f;
            const float height = 1.2f;

            var velocity = JumpMath.VelocityForHeight(height, gravity);
            var peak = velocity * velocity / (2f * gravity);

            Assert.That(peak, Is.EqualTo(height).Within(0.0001f));
        }

        [Test]
        public void VelocityForHeight_ZeroHeight_IsZero()
        {
            Assert.That(JumpMath.VelocityForHeight(0f, 9.81f), Is.EqualTo(0f));
        }

        [Test]
        public void VelocityForHeight_NegativeValues_AreZero()
        {
            Assert.That(JumpMath.VelocityForHeight(-1f, 9.81f), Is.EqualTo(0f));
            Assert.That(JumpMath.VelocityForHeight(1f, -9.81f), Is.EqualTo(0f));
        }
    }
}
