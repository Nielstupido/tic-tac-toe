using UnityEngine;
using UnityEngine.UI;

public class TextModifier : MonoBehaviour
{
    [SerializeField]private Text player1text;
    [SerializeField]private Text player2text;

    void Start()
    {
        if (PlayerPrefs.GetInt("PlayerNum") == 1)
        {
            player1text.fontSize = 99;
            player1text.color = Color.yellow;
        }
        else if (PlayerPrefs.GetInt("PlayerNum") == 2)
        {
            player2text.fontSize = 99;
            player2text.color = Color.yellow;
        }
    }
}
