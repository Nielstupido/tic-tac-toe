using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class GameMenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField]private GameObject loadingWindow;
    private int playerCountReady = 0;

    public void GotoMenu()
    {
        loadingWindow.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void PlayAgain()
    {
        loadingWindow.SetActive(true);
        photonView.RPC("PlayAgainRpc", RpcTarget.All);
    }

    [PunRPC]
    void PlayAgainRpc()
    {
        playerCountReady++;

        if (playerCountReady == 2)
            PhotonNetwork.LoadLevel("Game");
    }
}
