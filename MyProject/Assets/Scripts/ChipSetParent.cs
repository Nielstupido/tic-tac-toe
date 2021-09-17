using UnityEngine;
using Photon.Pun;

public class ChipSetParent : MonoBehaviourPunCallbacks
{
    private Transform newParent;


    void Start()
    {
        Debug.Log("chipInstantiated");

        if (photonView.IsMine)
        {
            if (PlayerPrefs.GetInt("PlayerNum") == 1)
                newParent = GameObject.Find("P1chips").transform;
            else
                newParent = GameObject.Find("P2chips").transform;
        }
        else
        {
            if (PlayerPrefs.GetInt("PlayerNum") == 1)
                newParent = GameObject.Find("P2chips").transform;
            else
                newParent = GameObject.Find("P1chips").transform;
        }
        
        this.photonView.RPC("SetParent", RpcTarget.All);
    }

    [PunRPC]
    void SetParent()
    {
        transform.SetParent(newParent, false);
    }
}
