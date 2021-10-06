using UnityEngine;
using UnityEngine.UI;

public class ChipTapColorManager : MonoBehaviour
{
    private GameObject currentSelectedChip;

    public GameObject CurrentSelectedChip 
    { 
        set{currentSelectedChip = value;}
        get{return currentSelectedChip;}
    }

    public void ChangeToDefaultColor()
    {
        if (PlayerPrefs.GetInt("PlayerNum") == 1)
            currentSelectedChip.GetComponent<Image>().color = Color.blue;
        else
            currentSelectedChip.GetComponent<Image>().color = Color.red;
    }
}
