using System.Collections;
using FishNet;
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
        private const float SpawnTimeoutSeconds = 10f;

        [UnityTearDown]
        public IEnumerator TearDown()
        {
            if (InstanceFinder.NetworkManager != null)
            {
                InstanceFinder.ClientManager.StopConnection();
                InstanceFinder.ServerManager.StopConnection(true);
            }

            yield return null;
        }

        [UnityTest]
        public IEnumerator FallingOffTheIsland_RespawnsAtTotem()
        {
            yield return SceneManager.LoadSceneAsync(PrototypeScene);
            FallRespawn player = null;
            var deadline = Time.realtimeSinceStartup + SpawnTimeoutSeconds;
            yield return new WaitUntil(() =>
                Time.realtimeSinceStartup > deadline || (player = FindOwnedPlayer()) != null);
            Assert.That(player, Is.Not.Null, "O host não criou o jogador a tempo.");

            var totem = Object.FindAnyObjectByType<Totem>();
            var body = player.GetComponent<Rigidbody>();

            body.position = new Vector3(500f, 0f, 500f);
            yield return new WaitForFixedUpdate();
            yield return new WaitUntil(() => body.isKinematic);
            yield return new WaitForSeconds(player.RespawnDelay + 0.3f);

            Assert.That(Vector3.Distance(body.position, totem.SpawnPosition), Is.LessThan(SpawnTolerance));
            Assert.That(body.isKinematic, Is.False);
        }

        private static FallRespawn FindOwnedPlayer()
        {
            var player = Object.FindAnyObjectByType<FallRespawn>();
            return player != null && player.enabled ? player : null;
        }
    }
}
