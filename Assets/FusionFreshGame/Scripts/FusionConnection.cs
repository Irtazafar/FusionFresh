using Fusion;
using Fusion.Sockets;
using StarterAssets;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace IrtazaGeni.FusionFresh
{
    public class FusionConnection : MonoBehaviour, INetworkRunnerCallbacks
    {

        public static FusionConnection instance;
        public bool connectOnAwake = false;
        [HideInInspector]
        public NetworkRunner runner;
        [SerializeField]
        NetworkObject playerPrefab;

        public string _playerName = string.Empty;
        private string _roomName = string.Empty;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            if(connectOnAwake==true)
            {
                ConnectToRunner("Anonymous","test");
            }
        }

        public async void ConnectToRunner(string playerName,string roomName)
        {
            _playerName = playerName;
            _roomName = roomName;

            if (runner == null)
            {
                runner = gameObject.AddComponent<NetworkRunner>();
            }

            await runner.StartGame(new StartGameArgs()
            {
                GameMode = GameMode.Shared,
                SessionName = _roomName,
                PlayerCount = 2,
                SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
            });

        }
        public void OnConnectedToServer(NetworkRunner runner)
        {
            Debug.Log("OnConnectedToServer");
            NetworkObject playerObject = runner.Spawn(playerPrefab,Vector3.zero);
            runner.SetPlayerObject(runner.LocalPlayer, playerObject);
            UICanvasControllerInput.instance.starterAssetsInputs=playerObject.GetComponent<StarterAssetsInputs>();
        }

        public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
        {

        }

        public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
        {

        }

        public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
        {

        }

        public void OnDisconnectedFromServer(NetworkRunner runner)
        {

        }

        public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {

        }

        public void OnInput(NetworkRunner runner, NetworkInput input)
        {

        }

        public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {

        }

        public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
            Debug.Log("OnPlayerJoined");
        }

        public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {

        }

        public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
        {

        }

        public void OnSceneLoadDone(NetworkRunner runner)
        {

        }

        public void OnSceneLoadStart(NetworkRunner runner)
        {

        }

        public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
        {

        }

        public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {

        }

        public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {

        }
    }
}


