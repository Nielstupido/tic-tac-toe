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
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomNameJoin.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
