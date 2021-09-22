using UnityEngine;
using Photon.Pun;

public class GameEndManager : MonoBehaviourPunCallbacks
{
    [SerializeField]private GameObject retryWindow;
    [SerializeField]private GameObject retryBoard;
    private int totalMoves = 0;

    public int TotalMoves { get{return totalMoves;}}

    public void ConnectToEvent()
    {
        photonView.RPC("Connect", RpcTarget.All);
    }

    [PunRPC]
    void Connect()
    {
        ChipsManager.OnFinishedMovingChip += OpenRetryWindow;
    }


    public void AddMoveCount()
    {
        photonView.RPC("AddCount", RpcTarget.All);
    }

    [PunRPC]
    void AddCount()
    {
        totalMoves++;
    }


    void OpenRetryWindow()
    {
        photonView.RPC("RetryWindow", RpcTarget.All);
    }

    [PunRPC]
    void RetryWindow()
    {
        ChipsManager.OnFinishedMovingChip -= OpenRetryWindow;
        retryWindow.SetActive(true);
        retryBoard.SetActive(true);
    }
}
