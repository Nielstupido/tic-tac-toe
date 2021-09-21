using UnityEngine;
using Photon.Pun;

public class GameEndManager : MonoBehaviourPunCallbacks
{
    private int totalMoves = 0;

    public void AddMoveCount()
    {
        photonView.RPC("AddCount", RpcTarget.All);
    }

    [PunRPC]
    void AddCount()
    {
        totalMoves++;

        if (totalMoves == 6)
        {
            PhotonNetwork.LoadLevel("Game");
        }
    }
}
