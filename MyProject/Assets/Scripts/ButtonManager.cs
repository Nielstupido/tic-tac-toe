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
        buttonNum = Convert.ToInt32(EventSystem.current.currentSelectedGameObject.name);
        EventSystem.current.currentSelectedGameObject.gameObject.SetActive(false);
        playerTurnManager.SwitchPlayerTurn();
        chipsManager.MoveChipTo(buttonNum);
    }
}
