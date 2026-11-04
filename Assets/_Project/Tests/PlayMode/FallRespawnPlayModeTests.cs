using System.Collections;
using NUnit.Framework;
using ProjetoLuz.Islands;
using ProjetoLuz.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace ProjetoLuz.Tests.PlayMode
{
    public class FallRespawnPlayModeTests
    {
        private const string PrototypeScene = "Prototype";
        private const float SpawnTolerance = 1.5f;

        [UnityTest]
        public IEnumerator FallingOffTheIsland_RespawnsAtTotem()
        {
            yield return SceneManager.LoadSceneAsync(PrototypeScene);
            var player = Object.FindAnyObjectByType<FallRespawn>();
            var totem = Object.FindAnyObjectByType<Totem>();
            var body = player.GetComponent<Rigidbody>();

            body.position = new Vector3(500f, 0f, 500f);
            yield return new WaitForFixedUpdate();
            yield return new WaitUntil(() => body.isKinematic);
            yield return new WaitForSeconds(player.RespawnDelay + 0.3f);

            Assert.That(Vector3.Distance(body.position, totem.SpawnPosition), Is.LessThan(SpawnTolerance));
            Assert.That(body.isKinematic, Is.False);
        }
    }
}
