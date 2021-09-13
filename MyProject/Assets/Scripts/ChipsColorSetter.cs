using UnityEngine;
using UnityEngine.UI;

public class ChipsColorSetter : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("PlayerNum") == 1)
            gameObject.GetComponent<Image>().color = Color.blue;
        else 
            gameObject.GetComponent<Image>().color = Color.red;
    }
}
