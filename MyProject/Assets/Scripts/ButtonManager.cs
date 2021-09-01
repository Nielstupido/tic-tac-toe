using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{
    private int buttonNum;
    private ChipsManager chipsManager;

    void Start()
    {
        chipsManager = FindObjectOfType<ChipsManager>();
    }

    public void PassButtonDets()
    {
        buttonNum = Convert.ToInt32(EventSystem.current.currentSelectedGameObject.name);
        EventSystem.current.currentSelectedGameObject.gameObject.SetActive(false);
        chipsManager.MoveChipTo(buttonNum);
    }
}
