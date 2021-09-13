using UnityEngine;

public class ChipSetParent : MonoBehaviour
{
    private Transform chipParent;

    void Start()
    {
        ChipsManager chipsManager = FindObjectOfType<ChipsManager>();
        chipsManager.playerChips.Add(this.gameObject);

        if (PlayerPrefs.GetInt("PlayerNum") == 1)
            chipParent = GameObject.Find("P1chips").transform;
        else 
            chipParent = GameObject.Find("P2chips").transform;
        
        transform.SetParent(chipParent, false);
    }
}
