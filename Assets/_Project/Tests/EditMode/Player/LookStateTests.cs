using NUnit.Framework;
using ProjetoLuz.Player;
using UnityEngine;

namespace ProjetoLuz.Tests.EditMode.Player
{
    public class LookStateTests
    {
        private const float Tolerance = 0.0001f;

        [Test]
        public void ApplyDelta_ScalesBySensitivity()
        {
            var look = new LookState(85f, 0f);

            look.ApplyDelta(new Vector2(10f, 0f), 0.5f);

            Assert.That(look.Yaw, Is.EqualTo(5f).Within(Tolerance));
        }

        [Test]
        public void ApplyDelta_MovingUp_LooksUp()
        {
            var look = new LookState(85f, 0f);

            look.ApplyDelta(new Vector2(0f, 10f), 1f);

            Assert.That(look.Pitch, Is.EqualTo(-10f).Within(Tolerance));
        }

        [Test]
        public void ApplyDelta_PitchIsClampedToLimit()
        {
            var look = new LookState(85f, 0f);

            look.ApplyDelta(new Vector2(0f, 1000f), 1f);
            Assert.That(look.Pitch, Is.EqualTo(-85f).Within(Tolerance));

            look.ApplyDelta(new Vector2(0f, -5000f), 1f);
            Assert.That(look.Pitch, Is.EqualTo(85f).Within(Tolerance));
        }

        [Test]
        public void ApplyDelta_YawWrapsAround()
        {
            var look = new LookState(85f, 350f);

            look.ApplyDelta(new Vector2(20f, 0f), 1f);

            Assert.That(look.Yaw, Is.EqualTo(10f).Within(Tolerance));
        }

        [Test]
        public void ApplyRate_ScalesByDeltaTime()
        {
            var look = new LookState(85f, 0f);

            look.ApplyRate(new Vector2(1f, 0f), 180f, 0.5f);

            Assert.That(look.Yaw, Is.EqualTo(90f).Within(Tolerance));
        }

        [Test]
        public void ApplyRate_SameTotalTimeGivesSameResultAtAnyStepSize()
        {
            var oneStep = new LookState(85f, 0f);
            var manySteps = new LookState(85f, 0f);

            oneStep.ApplyRate(new Vector2(0.7f, 0.3f), 120f, 0.1f);
            for (var i = 0; i < 10; i++)
                manySteps.ApplyRate(new Vector2(0.7f, 0.3f), 120f, 0.01f);

            Assert.That(manySteps.Yaw, Is.EqualTo(oneStep.Yaw).Within(Tolerance));
            Assert.That(manySteps.Pitch, Is.EqualTo(oneStep.Pitch).Within(Tolerance));
        }

        [Test]
        public void Constructor_KeepsInitialYawAndLevelPitch()
        {
            var look = new LookState(85f, 120f);

            Assert.That(look.Yaw, Is.EqualTo(120f).Within(Tolerance));
            Assert.That(look.Pitch, Is.EqualTo(0f));
        }

        [Test]
        public void AddYaw_RotatesYawAndWrapsWithoutTouchingPitch()
        {
            var look = new LookState(85f, 350f);
            look.ApplyDelta(new Vector2(0f, 10f), 1f);

            look.AddYaw(-370f);

            Assert.That(look.Yaw, Is.EqualTo(340f).Within(Tolerance));
            Assert.That(look.Pitch, Is.EqualTo(-10f).Within(Tolerance));
        }
    }
}
