using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Photon.Pun;

public class MovingChipsManager : MonoBehaviourPunCallbacks, IPointerClickHandler
{
    private ChipTapColorManager chipTapColorManager;
    private PlayerTurnManager playerTurnManager;
    private ButtonManager buttonManager;
    private GameEndManager gameEndManager;
    int currentButtonHolder;
    private bool isChipMoved = false;

    public bool IsChipMoved { set{isChipMoved = value;}}

    public int CurrentButtonHolder
    {
        get{return currentButtonHolder;} 
        set{currentButtonHolder = value;} 
    }

    void Start()
    {
        chipTapColorManager = FindObjectOfType<ChipTapColorManager>();
        playerTurnManager = FindObjectOfType<PlayerTurnManager>();
        buttonManager = FindObjectOfType<ButtonManager>();
        gameEndManager = FindObjectOfType<GameEndManager>();
    }

    public void OnPointerClick(PointerEventData pointer)
    {
        if(!photonView.IsMine)
        {
            return;
        }

        if(gameEndManager.TotalMoves < 6 && isChipMoved)
        {
            return;
        }
            
        Debug.Log("chipPressed");
        if (playerTurnManager.P1_turn && PlayerPrefs.GetInt("PlayerNum") == 1 
            || !playerTurnManager.P1_turn && PlayerPrefs.GetInt("PlayerNum") == 2)
        {
            if(chipTapColorManager.CurrentSelectedChip != null)
            {
                chipTapColorManager.ChangeToDefaultColor();
                buttonManager.HideAvailableButtons();
            }
            gameObject.GetComponent<Image>().color = Color.yellow;
            chipTapColorManager.CurrentSelectedChip = this.gameObject;
            buttonManager.SelectedChip = this.gameObject;
            buttonManager.ShowAvailableButtons(currentButtonHolder);
        }
    }
}