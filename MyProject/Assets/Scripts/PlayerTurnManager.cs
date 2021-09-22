using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerTurnManager : MonoBehaviourPunCallbacks
{
    [SerializeField]private Text playerTurnText;
    [SerializeField]private GameObject screenCover;
    private bool p1turn;

    public bool P1_turn { get{return p1turn;}}

    public override void OnEnable()
    {
        ChipsManager.OnFinishedMovingChip += ToggleTouchInputCover;
        ChipsManager.OnFinishedMovingChip += ToggleSwitchPlayer;
    }

    void OnDestroy()
    {
        ChipsManager.OnFinishedMovingChip -= ToggleTouchInputCover;
        ChipsManager.OnFinishedMovingChip -= ToggleSwitchPlayer;
    }

    void Start()
    {
        p1turn = true;
        Debug.Log("Game Start! /n Player 1's turn!");  
    }

    public void ToggleTouchInputCover()
    {
        screenCover.SetActive(!screenCover.activeSelf);
    }

    public void ToggleSwitchPlayer()
    {
        this.photonView.RPC("SwitchPlayerTurn", RpcTarget.All);
    }

    [PunRPC]
    void SwitchPlayerTurn()
    {
        p1turn = !p1turn;
        if (p1turn)
            playerTurnText.text = "Player 1's turn";
        else
            playerTurnText.text = "Player 2's turn";
    }
}
