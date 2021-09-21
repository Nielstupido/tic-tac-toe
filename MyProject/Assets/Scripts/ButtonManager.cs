using UnityEngine;
using System;
using UnityEngine.EventSystems;
using Photon.Pun;

public class ButtonManager : MonoBehaviourPunCallbacks
{
    private int buttonNum;
    private ChipsManager chipsManager;
    private PlayerTurnManager playerTurnManager;
    private GameArbiter gameArbiter;
    private GameObject pressedButton;

    void Start()
    {
        chipsManager = FindObjectOfType<ChipsManager>();
        playerTurnManager = GetComponent<PlayerTurnManager>();
        gameArbiter = FindObjectOfType<GameArbiter>();
    }

    public void PassButtonDets()
    {
        if (playerTurnManager.P1_turn && PlayerPrefs.GetInt("PlayerNum") == 1 || !playerTurnManager.P1_turn && PlayerPrefs.GetInt("PlayerNum") == 2)
        {
            playerTurnManager.ToggleTouchInputCover();
            buttonNum = Convert.ToInt32(EventSystem.current.currentSelectedGameObject.name);
            pressedButton = EventSystem.current.currentSelectedGameObject;
            photonView.RPC("DisableButton", RpcTarget.All);
            gameArbiter.ButtonNumPressed = buttonNum;
            chipsManager.MoveChipTo(buttonNum);
        }
    }

    [PunRPC]
    void DisableButton()
    {
        pressedButton.SetActive(false);
    }
}
