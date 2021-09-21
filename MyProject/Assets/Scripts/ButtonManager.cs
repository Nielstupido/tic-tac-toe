using UnityEngine;
using System;
using UnityEngine.EventSystems;
using Photon.Pun;

public class ButtonManager : MonoBehaviourPunCallbacks
{
    private int buttonNum;
    private ChipsManager chipsManager;
    private PlayerTurnManager playerTurnManager;
    private GameEndManager gameEndManager;
    private GameArbiter gameArbiter;
    private GameObject pressedButton;

    void Start()
    {
        chipsManager = FindObjectOfType<ChipsManager>();
        playerTurnManager = GetComponent<PlayerTurnManager>();
        gameArbiter = FindObjectOfType<GameArbiter>();
        gameEndManager = FindObjectOfType<GameEndManager>();
    }

    public void PassButtonDets()
    {
        if (playerTurnManager.P1_turn && PlayerPrefs.GetInt("PlayerNum") == 1 || !playerTurnManager.P1_turn && PlayerPrefs.GetInt("PlayerNum") == 2)
        {
            gameEndManager.AddMoveCount();
            playerTurnManager.ToggleTouchInputCover();
            buttonNum = Convert.ToInt32(EventSystem.current.currentSelectedGameObject.name);
            photonView.RPC("DisableButton", RpcTarget.All, buttonNum);
            gameArbiter.ButtonNumPressed = buttonNum;
            chipsManager.MoveChipTo(buttonNum);
        }
    }

    [PunRPC]
    void DisableButton(int playerNum)
    {
        int playerWinnerNum = playerNum;
        pressedButton = GameObject.Find(playerWinnerNum.ToString());
        pressedButton.SetActive(false);
    }
}
