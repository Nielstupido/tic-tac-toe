using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{
    private int buttonNum;
    private ChipsManager chipsManager;
    private PlayerTurnManager playerTurnManager;

    void Start()
    {
        chipsManager = FindObjectOfType<ChipsManager>();
        playerTurnManager = GetComponent<PlayerTurnManager>();
    }

    public void PassButtonDets()
    {
        if (playerTurnManager.P1_turn)
        {
            playerTurnManager.ToggleTouchInputCover();

            buttonNum = Convert.ToInt32(EventSystem.current.currentSelectedGameObject.name);
            EventSystem.current.currentSelectedGameObject.gameObject.SetActive(false);
            chipsManager.MoveChipTo(buttonNum);
        }
    }
}
