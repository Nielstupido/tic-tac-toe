using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnManager : MonoBehaviour
{
    [SerializeField]private Text playerTurnText;
    [SerializeField]private GameObject screenCover;
    private ChipsManager chipsManager;
    private bool p1turn;

    public bool P1_turn { get{return p1turn;}}

    void Start()
    {
        p1turn = true;
        chipsManager = FindObjectOfType<ChipsManager>();  
        Debug.Log("Game Start! /n Player 1's turn!");  
    }

    public void ToggleTouchInputCover()
    {
        screenCover.SetActive(!screenCover.activeSelf);
    }

    public void SwitchPlayerTurn()
    {
        p1turn = !p1turn;
        if (p1turn)
            playerTurnText.text = "Player 1's turn";
        else
            playerTurnText.text = "Player 2's turn";
    }
}
