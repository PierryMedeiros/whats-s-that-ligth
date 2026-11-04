using NUnit.Framework;

namespace ProjetoLuz.Tests.PlayMode
{
    public class ProjectInfoPlayModeTests
    {
        [Test]
        public void Codename_IsProjetoLuz()
        {
            Assert.AreEqual("ProjetoLuz", ProjectInfo.Codename);
        }
    }
}
