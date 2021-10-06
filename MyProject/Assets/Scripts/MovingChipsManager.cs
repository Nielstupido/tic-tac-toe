using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Photon.Pun;

public class MovingChipsManager : MonoBehaviourPunCallbacks, IPointerClickHandler
{
    private int currentButtonHolder;
    private ChipTapColorManager chipTapColorManager;
    private ButtonManager buttonManager;

    public int CurrentButtonHolder{set{currentButtonHolder = value;}}

    void Start()
    {
        chipTapColorManager = FindObjectOfType<ChipTapColorManager>();
        buttonManager = FindObjectOfType<ButtonManager>();
    }

    public void OnPointerClick(PointerEventData pointer)
    {
        if(photonView.IsMine)
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
