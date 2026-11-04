using NUnit.Framework;
using ProjetoLuz.Helicopter;

namespace ProjetoLuz.Tests.EditMode.Helicopter
{
    public class HelicopterTiltTests
    {
        private const float Tolerance = 0.0001f;

        [Test]
        public void Fraction_IsClampedBetweenMinusOneAndOne()
        {
            Assert.That(HelicopterTilt.Fraction(30f, 20f), Is.EqualTo(1f));
            Assert.That(HelicopterTilt.Fraction(-30f, 20f), Is.EqualTo(-1f));
            Assert.That(HelicopterTilt.Fraction(5f, 20f), Is.EqualTo(0.25f).Within(Tolerance));
        }

        [Test]
        public void Fraction_ZeroOrNegativeMax_IsZero()
        {
            Assert.That(HelicopterTilt.Fraction(5f, 0f), Is.EqualTo(0f));
            Assert.That(HelicopterTilt.Fraction(5f, -1f), Is.EqualTo(0f));
        }

        [Test]
        public void Pitch_AddsSpeedAndAccelerationContributions()
        {
            var pitch = HelicopterTilt.Pitch(0.5f, 0.5f, 10f, 8f, 30f);

            Assert.That(pitch, Is.EqualTo(9f).Within(Tolerance));
        }

        [Test]
        public void Pitch_IsClampedToMax()
        {
            Assert.That(HelicopterTilt.Pitch(1f, 1f, 10f, 10f, 12f), Is.EqualTo(12f).Within(Tolerance));
            Assert.That(HelicopterTilt.Pitch(-1f, -1f, 10f, 10f, 12f), Is.EqualTo(-12f).Within(Tolerance));
        }

        [Test]
        public void Pitch_NegativeMax_IsLevel()
        {
            Assert.That(HelicopterTilt.Pitch(1f, 1f, 10f, 10f, -5f), Is.EqualTo(0f));
        }

        [Test]
        public void Roll_TurningRight_BanksRight()
        {
            Assert.That(HelicopterTilt.Roll(1f, 15f), Is.EqualTo(-15f).Within(Tolerance));
        }

        [Test]
        public void Smooth_MovesPartWayTowardsTarget()
        {
            var value = HelicopterTilt.Smooth(0f, 10f, 5f, 0.1f);

            Assert.That(value, Is.GreaterThan(0f).And.LessThan(10f));
        }

        [Test]
        public void Smooth_SameTotalTimeGivesSameResultAtAnyStepSize()
        {
            var oneStep = HelicopterTilt.Smooth(0f, 10f, 4f, 0.5f);
            var manySteps = 0f;
            for (var i = 0; i < 25; i++)
                manySteps = HelicopterTilt.Smooth(manySteps, 10f, 4f, 0.02f);

            Assert.That(manySteps, Is.EqualTo(oneStep).Within(0.001f));
        }

        [Test]
        public void Smooth_ZeroSharpness_KeepsCurrent()
        {
            Assert.That(HelicopterTilt.Smooth(3f, 10f, 0f, 1f), Is.EqualTo(3f));
        }
    }
}
