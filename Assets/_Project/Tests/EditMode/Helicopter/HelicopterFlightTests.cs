using NUnit.Framework;
using ProjetoLuz.Helicopter;
using UnityEngine;

namespace ProjetoLuz.Tests.EditMode.Helicopter
{
    public class HelicopterFlightTests
    {
        private const float Tolerance = 0.0001f;

        [Test]
        public void TargetVelocity_ForwardWithZeroHeading_PointsAlongWorldForward()
        {
            var velocity = HelicopterFlight.TargetVelocity(1f, 0f, 0f, 20f, 6f);

            Assert.That(Vector3.Distance(velocity, new Vector3(0f, 0f, 20f)), Is.LessThan(Tolerance));
        }

        [Test]
        public void TargetVelocity_ForwardWithHeading90_PointsAlongWorldRight()
        {
            var velocity = HelicopterFlight.TargetVelocity(1f, 0f, 90f, 20f, 6f);

            Assert.That(Vector3.Distance(velocity, new Vector3(20f, 0f, 0f)), Is.LessThan(Tolerance));
        }

        [Test]
        public void TargetVelocity_LiftOnly_IsVertical()
        {
            var velocity = HelicopterFlight.TargetVelocity(0f, -1f, 45f, 20f, 6f);

            Assert.That(Vector3.Distance(velocity, new Vector3(0f, -6f, 0f)), Is.LessThan(Tolerance));
        }

        [Test]
        public void TargetVelocity_NoInput_IsHover()
        {
            var velocity = HelicopterFlight.TargetVelocity(0f, 0f, 30f, 20f, 6f);

            Assert.That(velocity, Is.EqualTo(Vector3.zero));
        }

        [Test]
        public void TargetVelocity_InputAboveOne_IsClamped()
        {
            var velocity = HelicopterFlight.TargetVelocity(3f, 2f, 0f, 20f, 6f);

            Assert.That(Vector3.Distance(velocity, new Vector3(0f, 6f, 20f)), Is.LessThan(Tolerance));
        }

        [Test]
        public void TargetVelocity_NegativeSpeeds_AreZero()
        {
            var velocity = HelicopterFlight.TargetVelocity(1f, 1f, 0f, -20f, -6f);

            Assert.That(velocity, Is.EqualTo(Vector3.zero));
        }

        [Test]
        public void Accelerate_UsesSeparateHorizontalAndVerticalRates()
        {
            var velocity = HelicopterFlight.Accelerate(Vector3.zero, new Vector3(0f, 10f, 10f), 4f, 2f, 1f);

            Assert.That(Vector3.Distance(velocity, new Vector3(0f, 2f, 4f)), Is.LessThan(Tolerance));
        }

        [Test]
        public void Accelerate_DoesNotOvershootTarget()
        {
            var target = new Vector3(1f, 1f, 0f);

            var velocity = HelicopterFlight.Accelerate(Vector3.zero, target, 100f, 100f, 1f);

            Assert.That(Vector3.Distance(velocity, target), Is.LessThan(Tolerance));
        }

        [Test]
        public void Accelerate_SameTotalTimeGivesSameResultAtAnyStepSize()
        {
            var target = new Vector3(10f, 5f, 10f);
            var oneStep = HelicopterFlight.Accelerate(Vector3.zero, target, 3f, 2f, 1f);
            var manySteps = Vector3.zero;
            for (var i = 0; i < 50; i++)
                manySteps = HelicopterFlight.Accelerate(manySteps, target, 3f, 2f, 0.02f);

            Assert.That(Vector3.Distance(oneStep, manySteps), Is.LessThan(0.001f));
        }

        [Test]
        public void Accelerate_NegativeRates_KeepCurrentVelocity()
        {
            var current = new Vector3(1f, 2f, 3f);

            var velocity = HelicopterFlight.Accelerate(current, Vector3.zero, -5f, -5f, 1f);

            Assert.That(velocity, Is.EqualTo(current));
        }

        [Test]
        public void YawRate_AcceleratesTowardsTurnInput()
        {
            var rate = HelicopterFlight.YawRate(0f, 1f, 90f, 60f, 0.5f);

            Assert.That(rate, Is.EqualTo(30f).Within(Tolerance));
        }

        [Test]
        public void YawRate_DoesNotExceedMax()
        {
            var rate = HelicopterFlight.YawRate(80f, 5f, 90f, 1000f, 1f);

            Assert.That(rate, Is.EqualTo(90f).Within(Tolerance));
        }

        [Test]
        public void YawRate_NoInput_SlowsDownToZero()
        {
            var rate = HelicopterFlight.YawRate(-20f, 0f, 90f, 60f, 1f);

            Assert.That(rate, Is.EqualTo(0f).Within(Tolerance));
        }
    }
}
