using UnityEngine;
using UnityEngine.UI;

public class ChipsColorSetter : MonoBehaviour
{
    void Awake()
    {
        if (PlayerPrefs.GetInt("PlayerNum") == 1)
            gameObject.GetComponent<Image>().color = Color.blue;
        else if (PlayerPrefs.GetInt("PlayerNum") == 2)
            gameObject.GetComponent<Image>().color = Color.red;
    }
}
