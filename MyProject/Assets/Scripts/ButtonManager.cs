using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using Photon.Pun;

public class ButtonManager : MonoBehaviourPunCallbacks
{
    [SerializeField]private List<GameObject> availButtons;
    private List<GameObject> unAvailButtons;
    private ChipsManager chipsManager;
    private PlayerTurnManager playerTurnManager;
    private GameEndManager gameEndManager;
    private GameArbiter gameArbiter;
    private GameObject pressedButton, selectedChip;

    public GameObject SelectedChip{ set{selectedChip = value;}}

    void Start()
    {
        chipsManager = FindObjectOfType<ChipsManager>();
        playerTurnManager = GetComponent<PlayerTurnManager>();
        gameArbiter = FindObjectOfType<GameArbiter>();
        gameEndManager = FindObjectOfType<GameEndManager>();
    }

    public void ShowAvailableButtons(int currentButtonHolder)
    {
        if(gameEndManager.TotalMoves < 6)
        {
            foreach(GameObject btn in availButtons)
            {
                btn.SetActive(true);
            }
        }
        else
        {
            if(currentButtonHolder == 1)
            {
                foreach(GameObject btn in availButtons)
                {
                    if(btn.name.Equals("2") || btn.name.Equals("5") || btn.name.Equals("6"))
                    {
                        btn.SetActive(true);
                    }
                }
            }
            else if(currentButtonHolder == 2)
            {
                foreach(GameObject btn in availButtons)
                {
                    if(btn.name.Equals("1") || btn.name.Equals("3") || btn.name.Equals("5"))
                    {
                        btn.SetActive(true);
                    }
                }
            }
            else if(currentButtonHolder == 3)
            {
                foreach(GameObject btn in availButtons)
                {
                    if(btn.name.Equals("2") || btn.name.Equals("4") || btn.name.Equals("5"))
                    {
                        btn.SetActive(true);
                    }
                }
            }
            else if(currentButtonHolder == 4)
            {
                foreach(GameObject btn in availButtons)
                {
                    if(btn.name.Equals("3") || btn.name.Equals("5") || btn.name.Equals("9"))
                    {
                        btn.SetActive(true);
                    }
                }
            }
            else if(currentButtonHolder == 5)
            {
                foreach(GameObject btn in availButtons)
                {
                    if(btn.name.Equals("1") || btn.name.Equals("2") || btn.name.Equals("3") || btn.name.Equals("4") 
                        || btn.name.Equals("6") || btn.name.Equals("7") || btn.name.Equals("8") || btn.name.Equals("9"))
                    {
                        btn.SetActive(true);
                    }
                }
            }
            else if(currentButtonHolder == 6)
            {
                foreach(GameObject btn in availButtons)
                {
                    if(btn.name.Equals("1") || btn.name.Equals("5") || btn.name.Equals("7"))
                    {
                        btn.SetActive(true);
                    }
                }
            }
            else if(currentButtonHolder == 7)
            {
                foreach(GameObject btn in availButtons)
                {
                    if(btn.name.Equals("5") || btn.name.Equals("6") || btn.name.Equals("8"))
                    {
                        btn.SetActive(true);
                    }
                }
            }
            else if(currentButtonHolder == 8)
            {
                foreach(GameObject btn in availButtons)
                {
                    if(btn.name.Equals("5") || btn.name.Equals("7") || btn.name.Equals("9"))
                    {
                        btn.SetActive(true);
                    }
                }
            }
            else if(currentButtonHolder == 9)
            {
                foreach(GameObject btn in availButtons)
                {
                    if(btn.name.Equals("4") || btn.name.Equals("5") || btn.name.Equals("8"))
                    {
                        btn.SetActive(true);
                    }
                }
            }
        }//main else sttmnt
    }//ShowAvailButtons

    public void HideAvailableButtons()
    {
        foreach(GameObject btn in availButtons)
        {
            btn.SetActive(false);
        }
    }


    public void PassButtonDets()
    {
        if (playerTurnManager.P1_turn && PlayerPrefs.GetInt("PlayerNum") == 1 
            || !playerTurnManager.P1_turn && PlayerPrefs.GetInt("PlayerNum") == 2)
        {
            gameEndManager.AddMoveCount();
            playerTurnManager.ToggleTouchInputCover();
            pressedButton = EventSystem.current.currentSelectedGameObject;
            photonView.RPC("DisableButton", RpcTarget.All, pressedButton);
            gameArbiter.ButtonNumPressed = Convert.ToInt32(pressedButton.name);
            chipsManager.MoveChipTo(pressedButton, selectedChip);
            selectedChip.GetComponent<MovingChipsManager>().CurrentButtonHolder = Convert.ToInt32(pressedButton.name);
        }
    }

    [PunRPC]
    void DisableButton(GameObject pressedBtn)
    {
        pressedBtn.SetActive(false);

        foreach(GameObject btn in availButtons)
        {
            if(btn.name.Equals(pressedBtn.name))
            {
                availButtons.Remove(btn);
                unAvailButtons.Add(btn);
                return;
            }
        }
    }
}
