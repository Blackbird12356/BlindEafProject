using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : NetworkBehaviour, IPlayerJoined, IPlayerLeft
{
    [SerializeField] private NetworkPrefabRef playerPrefab;
    [Networked, Capacity(2)] private NetworkDictionary<PlayerRef, FPPlayer> Players => default;

    public void PlayerJoined(PlayerRef player)
    {
        if (HasStateAuthority)
        {
            NetworkObject playerObject = Runner.Spawn(playerPrefab, Vector3.up, Quaternion.identity, player);
            Players.Add(player, playerObject.GetComponent<FPPlayer>());
        }
    }

    public void PlayerLeft(PlayerRef player)
    {
        if (!HasInputAuthority)
            return;

        if(Players.TryGet(player, out FPPlayer playerBehaviour))
        {
            Players.Remove(player);
            Runner.Despawn(playerBehaviour.Object);
        }
    }
}
