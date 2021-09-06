using UnityEngine;

public class ChipSetParent : MonoBehaviour
{
    void Awake()
    {
        if (PlayerPrefs.GetInt("PlayerNum") == 1)
        {
            Transform chipParent = GameObject.Find("P1chips").transform;
            transform.SetParent(chipParent, false);
        }
        else if(PlayerPrefs.GetInt("PlayerNum") == 2)
        {
            Transform chipParent = GameObject.Find("P1chips").transform;
            transform.SetParent(chipParent, false);
        }
    }
}
