using NUnit.Framework;
using ProjetoLuz.Helicopter;

namespace ProjetoLuz.Tests.EditMode.Helicopter
{
    public class PilotSeatRuleTests
    {
        [Test]
        public void CanEnter_FreeSeatInRange_IsTrue()
        {
            Assert.That(PilotSeatRule.CanEnter(false, 2f, 3f), Is.True);
        }

        [Test]
        public void CanEnter_ExactlyAtMaxDistance_IsTrue()
        {
            Assert.That(PilotSeatRule.CanEnter(false, 3f, 3f), Is.True);
        }

        [Test]
        public void CanEnter_OccupiedSeat_IsFalse()
        {
            Assert.That(PilotSeatRule.CanEnter(true, 1f, 3f), Is.False);
        }

        [Test]
        public void CanEnter_OutOfRange_IsFalse()
        {
            Assert.That(PilotSeatRule.CanEnter(false, 3.1f, 3f), Is.False);
        }
    }
}
