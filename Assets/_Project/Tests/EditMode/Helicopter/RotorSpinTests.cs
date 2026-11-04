using NUnit.Framework;
using ProjetoLuz.Helicopter;

namespace ProjetoLuz.Tests.EditMode.Helicopter
{
    public class RotorSpinTests
    {
        private const float Tolerance = 0.0001f;

        [Test]
        public void Step_EngineOn_SpinsUpAtSpinUpRate()
        {
            var speed = RotorSpin.Step(0f, true, 1000f, 200f, 100f, 1f);

            Assert.That(speed, Is.EqualTo(200f).Within(Tolerance));
        }

        [Test]
        public void Step_EngineOn_DoesNotExceedMax()
        {
            var speed = RotorSpin.Step(950f, true, 1000f, 200f, 100f, 1f);

            Assert.That(speed, Is.EqualTo(1000f).Within(Tolerance));
        }

        [Test]
        public void Step_EngineOff_SpinsDownAtSpinDownRate()
        {
            var speed = RotorSpin.Step(1000f, false, 1000f, 200f, 100f, 1f);

            Assert.That(speed, Is.EqualTo(900f).Within(Tolerance));
        }

        [Test]
        public void Step_EngineOff_StopsAtZero()
        {
            var speed = RotorSpin.Step(50f, false, 1000f, 200f, 100f, 1f);

            Assert.That(speed, Is.EqualTo(0f));
        }

        [Test]
        public void Step_NegativeRate_KeepsCurrentSpeed()
        {
            var speed = RotorSpin.Step(500f, true, 1000f, -200f, 100f, 1f);

            Assert.That(speed, Is.EqualTo(500f));
        }
    }
}
