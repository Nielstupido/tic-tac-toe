using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{
    private int buttonNum;

    void PassButtonDets()
    {
        buttonNum = Convert.ToInt32(EventSystem.current.currentSelectedGameObject.name);
        EventSystem.current.currentSelectedGameObject.gameObject.SetActive(false);
    }
}
