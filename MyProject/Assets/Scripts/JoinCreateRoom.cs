using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class JoinCreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField]private InputField roomNameCreate;
    [SerializeField]private InputField roomNameJoin;

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
        PhotonNetwork.LoadLevel("Game");
    }
}
