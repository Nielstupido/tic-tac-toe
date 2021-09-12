using UnityEngine;

public class ChipSetParent : MonoBehaviour
{
    void Awake()
    {
        ChipsManager chipsManager = FindObjectOfType<ChipsManager>();
        if (PlayerPrefs.GetInt("PlayerNum") == 1)
        {
            chipsManager.playerChips1.Add(gameObject);
        }
        else if (PlayerPrefs.GetInt("PlayerNum") == 2)
        {
            chipsManager.playerChips2.Add(gameObject);
        }


        if (PlayerPrefs.GetInt("PlayerNum") == 1)
        {
            Transform chipParent = GameObject.Find("P1chips").transform;
            transform.SetParent(chipParent, false);
        }
        else if(PlayerPrefs.GetInt("PlayerNum") == 2)
        {
            Transform chipParent = GameObject.Find("P2chips").transform;
            transform.SetParent(chipParent, false);
        }
    }
}
