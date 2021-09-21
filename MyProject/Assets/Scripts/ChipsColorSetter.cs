using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ChipsColorSetter : MonoBehaviourPunCallbacks
{
    void Start()
    {
        if (photonView.IsMine)
        {
            if (PlayerPrefs.GetInt("PlayerNum") == 1)
                gameObject.GetComponent<Image>().color = Color.blue;
            else
                gameObject.GetComponent<Image>().color = Color.red;
        }
        else
        {
            if (PlayerPrefs.GetInt("PlayerNum") == 1)
                gameObject.GetComponent<Image>().color = Color.red;
            else
                gameObject.GetComponent<Image>().color = Color.blue;
        }
    }
}
