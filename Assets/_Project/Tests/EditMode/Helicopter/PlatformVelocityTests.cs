using NUnit.Framework;
using ProjetoLuz.Helicopter;
using UnityEngine;

namespace ProjetoLuz.Tests.EditMode.Helicopter
{
    public class PlatformVelocityTests
    {
        private const float Tolerance = 0.001f;

        [Test]
        public void Track_SteadyMotion_ConvergesToMeasuredVelocity()
        {
            var velocity = Vector3.zero;
            var position = Vector3.zero;
            for (var i = 0; i < 200; i++)
            {
                var next = position + new Vector3(0.1f, 0f, 0f);
                velocity = PlatformVelocity.Track(velocity, position, next, 10f, 0.02f);
                position = next;
            }

            Assert.That(Vector3.Distance(velocity, new Vector3(5f, 0f, 0f)), Is.LessThan(Tolerance));
        }

        [Test]
        public void Track_OneStep_MovesPartWayTowardsMeasured()
        {
            var velocity = PlatformVelocity.Track(Vector3.zero, Vector3.zero, Vector3.forward, 5f, 0.1f);

            Assert.That(velocity.z, Is.GreaterThan(0f).And.LessThan(10f));
        }

        [Test]
        public void Track_ZeroDeltaTime_KeepsCurrent()
        {
            var current = new Vector3(1f, 2f, 3f);

            var velocity = PlatformVelocity.Track(current, Vector3.zero, Vector3.one, 5f, 0f);

            Assert.That(velocity, Is.EqualTo(current));
        }

        [Test]
        public void Carry_MovesByPlatformVelocityOverTheStep()
        {
            var position = PlatformVelocity.Carry(new Vector3(1f, 2f, 3f), new Vector3(10f, 0f, -5f), 0.1f);

            Assert.That(Vector3.Distance(position, new Vector3(2f, 2f, 2.5f)), Is.LessThan(Tolerance));
        }

        [Test]
        public void Carry_StillPlatformOrNegativeTime_KeepsPosition()
        {
            var start = new Vector3(1f, 2f, 3f);

            Assert.That(PlatformVelocity.Carry(start, Vector3.zero, 0.1f), Is.EqualTo(start));
            Assert.That(PlatformVelocity.Carry(start, Vector3.one, -1f), Is.EqualTo(start));
        }

        [Test]
        public void ToRelativeThenToWorld_RoundTrips()
        {
            var world = new Vector3(3f, -1f, 7f);
            var platform = new Vector3(10f, 2f, -4f);

            var relative = PlatformVelocity.ToRelative(world, platform);

            Assert.That(PlatformVelocity.ToWorld(relative, platform), Is.EqualTo(world));
            Assert.That(relative, Is.EqualTo(new Vector3(-7f, -3f, 11f)));
        }
    }
}
