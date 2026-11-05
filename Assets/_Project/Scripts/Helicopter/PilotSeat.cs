using System;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Transporting;
using UnityEngine;

namespace ProjetoLuz.Helicopter
{
    public sealed class PilotSeat : NetworkBehaviour
    {
        [SerializeField] private HelicopterBody _helicopter;
        [SerializeField] private HelicopterMotor _motor;
        [SerializeField] private Transform _exitPoint;
        [SerializeField, Min(0f)] private float _maxEnterDistance = 4f;

        private readonly SyncVar<NetworkObject> _pilot = new();

        private NetworkConnection _pilotConnection;
        private SeatedPlayer _seatedPilot;

        public event Action<bool> OccupiedChanged;

        public bool IsOccupied => _pilot.Value != null;

        private bool IsPilotedOnServer => _pilotConnection != null;

        private void Awake()
        {
            _pilot.OnChange += OnPilotChanged;
        }

        private void OnDestroy()
        {
            _pilot.OnChange -= OnPilotChanged;
        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            ServerManager.OnRemoteConnectionState += ReleaseWhenPilotDisconnects;
        }

        public override void OnStopServer()
        {
            base.OnStopServer();
            ServerManager.OnRemoteConnectionState -= ReleaseWhenPilotDisconnects;
        }

        public void RequestEnter(NetworkObject player)
        {
            ServerEnter(player);
        }

        public void RequestExit()
        {
            ServerExit(_helicopter.Body.linearVelocity);
        }

        [ServerRpc(RequireOwnership = false)]
        private void ServerEnter(NetworkObject player, NetworkConnection caller = null)
        {
            if (player == null || player.Owner != caller)
                return;

            var distance = Vector3.Distance(player.transform.position, transform.position);
            if (!PilotSeatRule.CanEnter(IsPilotedOnServer, distance, _maxEnterDistance))
                return;

            _pilot.Value = player;
            _pilotConnection = caller;
            _helicopter.HandOver(caller);
        }

        [ServerRpc(RequireOwnership = false)]
        private void ServerExit(Vector3 velocity, NetworkConnection caller = null)
        {
            if (!IsPilotedOnServer || _pilotConnection != caller)
                return;

            Release(velocity);
        }

        private void ReleaseWhenPilotDisconnects(NetworkConnection connection, RemoteConnectionStateArgs args)
        {
            if (args.ConnectionState != RemoteConnectionState.Stopped || !IsPilotedOnServer || _pilotConnection != connection)
                return;

            Release(Vector3.zero);
        }

        private void Release(Vector3 velocity)
        {
            _pilot.Value = null;
            _pilotConnection = null;
            _helicopter.TakeBack(velocity);
        }

        // On host FishNet passes the already updated value as "previous", so the seated pilot is tracked here instead.
        private void OnPilotChanged(NetworkObject previous, NetworkObject next, bool asServer)
        {
            if (asServer)
                return;

            StandUpSeatedPilot();
            if (next != null && next.TryGetComponent(out SeatedPlayer nextPilot))
                SitDown(nextPilot);

            OccupiedChanged?.Invoke(next != null);
        }

        private void SitDown(SeatedPlayer pilot)
        {
            _seatedPilot = pilot;
            pilot.Sit(this);
            if (pilot.IsOwner)
                _motor.SetPilotInput(pilot.Input);
        }

        private void StandUpSeatedPilot()
        {
            if (_seatedPilot == null)
                return;

            if (_seatedPilot.IsOwner)
                _motor.SetPilotInput(null);

            _seatedPilot.Stand(_exitPoint.position);
            _seatedPilot = null;
        }
    }
}
