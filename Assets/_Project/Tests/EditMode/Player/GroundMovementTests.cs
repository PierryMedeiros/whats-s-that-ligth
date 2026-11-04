using NUnit.Framework;
using ProjetoLuz.Player;
using UnityEngine;

namespace ProjetoLuz.Tests.EditMode.Player
{
    public class GroundMovementTests
    {
        private const float Tolerance = 0.0001f;

        [Test]
        public void TargetVelocity_ForwardInputWithZeroYaw_PointsAlongWorldForward()
        {
            var velocity = GroundMovement.TargetVelocity(Vector2.up, 0f, 5f);

            Assert.That(Vector3.Distance(velocity, new Vector3(0f, 0f, 5f)), Is.LessThan(Tolerance));
        }

        [Test]
        public void TargetVelocity_ForwardInputWithYaw90_PointsAlongWorldRight()
        {
            var velocity = GroundMovement.TargetVelocity(Vector2.up, 90f, 5f);

            Assert.That(Vector3.Distance(velocity, new Vector3(5f, 0f, 0f)), Is.LessThan(Tolerance));
        }

        [Test]
        public void TargetVelocity_DiagonalInput_IsNotFasterThanSpeed()
        {
            var velocity = GroundMovement.TargetVelocity(new Vector2(1f, 1f), 0f, 5f);

            Assert.That(velocity.magnitude, Is.EqualTo(5f).Within(Tolerance));
        }

        [Test]
        public void TargetVelocity_PartialInput_KeepsAnalogMagnitude()
        {
            var velocity = GroundMovement.TargetVelocity(new Vector2(0f, 0.5f), 0f, 4f);

            Assert.That(velocity.magnitude, Is.EqualTo(2f).Within(Tolerance));
        }

        [Test]
        public void TargetVelocity_NegativeSpeed_IsZero()
        {
            var velocity = GroundMovement.TargetVelocity(Vector2.up, 0f, -5f);

            Assert.That(velocity, Is.EqualTo(Vector3.zero));
        }

        [Test]
        public void TargetVelocity_IsAlwaysHorizontal()
        {
            var velocity = GroundMovement.TargetVelocity(new Vector2(0.3f, -0.8f), 37f, 6f);

            Assert.That(velocity.y, Is.EqualTo(0f));
        }

        [Test]
        public void BlockIntoSteepSurface_MovingIntoSurface_RemovesThatComponent()
        {
            var normal = Quaternion.Euler(-55f, 0f, 0f) * Vector3.up;
            var target = new Vector3(2f, 0f, 5f);

            var blocked = GroundMovement.BlockIntoSteepSurface(target, normal);

            Assert.That(Vector3.Distance(blocked, new Vector3(2f, 0f, 0f)), Is.LessThan(Tolerance));
        }

        [Test]
        public void BlockIntoSteepSurface_MovingAwayFromSurface_KeepsTarget()
        {
            var normal = Quaternion.Euler(-55f, 0f, 0f) * Vector3.up;
            var target = new Vector3(0f, 0f, -5f);

            var blocked = GroundMovement.BlockIntoSteepSurface(target, normal);

            Assert.That(blocked, Is.EqualTo(target));
        }

        [Test]
        public void BlockIntoSteepSurface_FlatNormal_KeepsTarget()
        {
            var target = new Vector3(1f, 0f, 1f);

            var blocked = GroundMovement.BlockIntoSteepSurface(target, Vector3.up);

            Assert.That(blocked, Is.EqualTo(target));
        }

        [Test]
        public void Accelerate_ChangesVelocityByAccelerationTimesDeltaTime()
        {
            var velocity = GroundMovement.Accelerate(Vector3.zero, new Vector3(10f, 0f, 0f), 20f, 0.1f);

            Assert.That(velocity.x, Is.EqualTo(2f).Within(Tolerance));
        }

        [Test]
        public void Accelerate_DoesNotOvershootTarget()
        {
            var velocity = GroundMovement.Accelerate(Vector3.zero, new Vector3(1f, 0f, 0f), 100f, 1f);

            Assert.That(velocity.x, Is.EqualTo(1f).Within(Tolerance));
        }

        [Test]
        public void Accelerate_SameTotalTimeGivesSameResultAtAnyStepSize()
        {
            var target = new Vector3(10f, 0f, 0f);
            var oneStep = GroundMovement.Accelerate(Vector3.zero, target, 20f, 0.2f);
            var fourSteps = Vector3.zero;
            for (var i = 0; i < 4; i++)
                fourSteps = GroundMovement.Accelerate(fourSteps, target, 20f, 0.05f);

            Assert.That(Vector3.Distance(oneStep, fourSteps), Is.LessThan(Tolerance));
        }

        [Test]
        public void Accelerate_NegativeAcceleration_KeepsCurrentVelocity()
        {
            var current = new Vector3(3f, 0f, 0f);

            var velocity = GroundMovement.Accelerate(current, Vector3.zero, -20f, 0.1f);

            Assert.That(velocity, Is.EqualTo(current));
        }
    }
}
