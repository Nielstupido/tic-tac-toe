using UnityEngine;
using Photon.Pun;

public class ChipSetParent : MonoBehaviourPunCallbacks
{
    private Transform chipParent;

    void Start()
    {
        ChipsManager chipsManager = FindObjectOfType<ChipsManager>();
        chipsManager.playerChips.Add(this.gameObject);

        this.photonView.RPC("SetParent", RpcTarget.All);
    }

    [PunRPC]
    void SetParent()
    {
        if (PlayerPrefs.GetInt("PlayerNum") == 1)
            chipParent = GameObject.Find("P1chips").transform;
        else 
            chipParent = GameObject.Find("P2chips").transform;
        
        transform.SetParent(chipParent, false);
    }
}
