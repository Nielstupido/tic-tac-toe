using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnManager : MonoBehaviour
{
    [SerializeField]private Text playerTurnText;
    [SerializeField]private GameObject screenCover;
    private ChipsManager chipsManager;

    void Start()
    {
        chipsManager = FindObjectOfType<ChipsManager>();  
        Debug.Log("Game Start! /n Player 1's turn!");  
    }

    public void ToggleTouchInputCover()
    {
        screenCover.SetActive(!screenCover.activeSelf);
    }

    public void SwitchPlayerTurn(bool p1_turn)
    {
        if (p1_turn)
            playerTurnText.text = "Player 1's turn";
        else
            playerTurnText.text = "Player 2's turn";
    }
}
