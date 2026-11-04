using NUnit.Framework;
using ProjetoLuz.Player;
using UnityEngine;

namespace ProjetoLuz.Tests.EditMode.Player
{
    public class GroundRuleTests
    {
        [Test]
        public void IsWalkable_FlatGround_IsTrue()
        {
            Assert.That(GroundRule.IsWalkable(Vector3.up, 45f), Is.True);
        }

        [Test]
        public void IsWalkable_SlopeJustBelowLimit_IsTrue()
        {
            var normal = Quaternion.Euler(0f, 0f, 44.9f) * Vector3.up;

            Assert.That(GroundRule.IsWalkable(normal, 45f), Is.True);
        }

        [Test]
        public void IsWalkable_SlopeAboveLimit_IsFalse()
        {
            var normal = Quaternion.Euler(0f, 0f, 46f) * Vector3.up;

            Assert.That(GroundRule.IsWalkable(normal, 45f), Is.False);
        }

        [Test]
        public void IsWalkable_Wall_IsFalse()
        {
            Assert.That(GroundRule.IsWalkable(Vector3.right, 45f), Is.False);
        }
    }
}
