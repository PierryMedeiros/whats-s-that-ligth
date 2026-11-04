using NUnit.Framework;

namespace ProjetoLuz.Tests.EditMode
{
    public class ProjectInfoTests
    {
        [Test]
        public void Codename_IsProjetoLuz()
        {
            Assert.AreEqual("ProjetoLuz", ProjectInfo.Codename);
        }
    }
}
