using UnityEngine;
using Mirror;

namespace Peplayon
{
    [AddComponentMenu("")]
    public class NetworkManagerPong : NetworkManager

    {
        public NetworkIdentity[] _item = null;

        public Transform[] PointSpawnItem;

        public Transform spawnplayer;

        public Transform ItemParent;

        public override void OnStartServer()
        {
            base.OnStartServer();
            SpawnItem.Spawnitemrandom();
        }

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            GameObject player = Instantiate(playerPrefab, spawnplayer.position, spawnplayer.rotation);

            NetworkServer.AddPlayerForConnection(conn, player);
        }

        public override void OnServerDisconnect(NetworkConnection conn)
        {
            base.OnServerDisconnect(conn);
        }
    }
}