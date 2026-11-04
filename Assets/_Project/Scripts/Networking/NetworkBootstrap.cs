using FishNet.Managing;
using FishNet.Transporting;
using Unity.Multiplayer.PlayMode;
using UnityEngine;

namespace ProjetoLuz.Networking
{
    public sealed class NetworkBootstrap : MonoBehaviour
    {
        [SerializeField] private NetworkManager _networkManager;
        [SerializeField, Min(0f)] private float _clientRetrySeconds = 1f;

        private static bool IsAdditionalEditorInstance => Application.isEditor && !CurrentPlayer.IsMainEditor;

        private void Start()
        {
            if (IsAdditionalEditorInstance)
            {
                _networkManager.ClientManager.OnClientConnectionState += RetryWhenStopped;
                ConnectClient();
                return;
            }

            _networkManager.ServerManager.StartConnection();
            _networkManager.ClientManager.StartConnection();
        }

        private void OnDestroy()
        {
            if (_networkManager != null)
                _networkManager.ClientManager.OnClientConnectionState -= RetryWhenStopped;
        }

        private void RetryWhenStopped(ClientConnectionStateArgs args)
        {
            if (args.ConnectionState != LocalConnectionState.Stopped)
                return;

            Invoke(nameof(ConnectClient), _clientRetrySeconds);
        }

        private void ConnectClient()
        {
            _networkManager.ClientManager.StartConnection();
        }
    }
}
