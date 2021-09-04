using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class JoinCreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField]private InputField roomNameCreate;
    [SerializeField]private InputField roomNameJoin;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(roomNameCreate.text);
        PlayerPrefs.SetInt("PlayerNum", 1);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomNameJoin.text);
        PlayerPrefs.SetInt("PlayerNum", 2);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
