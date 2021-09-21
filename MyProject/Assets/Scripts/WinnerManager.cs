using UnityEngine;
using UnityEngine.UI;

public class WinnerManager : MonoBehaviour
{
    [SerializeField] private Text winner;
    private GameArbiter gameArbiter;

    void Start()
    {
        gameArbiter = FindObjectOfType<GameArbiter>();
        winner.text = "Player " + gameArbiter.WinnerNum + " Wins!!";
    }
}
