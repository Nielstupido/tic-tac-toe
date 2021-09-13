using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class JoinCreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField]private InputField roomNameCreate;
    [SerializeField]private InputField roomNameJoin;
    [SerializeField]private GameObject waitingWindow;
    private int playerCountReady = 0;

    public void CreateRoom()
    {
        PlayerPrefs.SetInt("PlayerNum", 1);
        PhotonNetwork.CreateRoom(roomNameCreate.text);
    }

    public void JoinRoom()
    {
        PlayerPrefs.SetInt("PlayerNum", 2);
        PhotonNetwork.JoinRoom(roomNameJoin.text);
    }

    public override void OnJoinedRoom()
    {
        waitingWindow.SetActive(true);
    }

    public void OnReady()
    {
        this.photonView.RPC("AddPlayerCount", RpcTarget.All);
    }

    [PunRPC]
    void AddPlayerCount()
    {
        playerCountReady++;

        if (playerCountReady == 2)
            PhotonNetwork.LoadLevel("Game");
    }
}
