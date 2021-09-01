using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnManager : MonoBehaviour
{
    [SerializeField]private Text playerTurnText;
    private ChipsManager chipsManager;
    private bool p1_turn = true;

    void Start()
    {
        chipsManager = FindObjectOfType<ChipsManager>();  
        Debug.Log("Game Start! /n Player 1's turn!");  
    }

    public void SwitchPlayerTurn()
    {
        chipsManager.P1_turn = p1_turn;
        p1_turn = !p1_turn;

        if (p1_turn)
            playerTurnText.text = "Player 1's turn";
        else
            playerTurnText.text = "Player 2's turn";
    }
}
