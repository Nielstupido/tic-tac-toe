using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChipsManager : MonoBehaviour
{
    [SerializeField]private GameObject[] placeHolders;
    private PlayerTurnManager playerTurnManager;
    private Transform chipTransform;
    private float smoothing = 6f;
    private Vector3 targetPos;

    public List<GameObject> playerChips1 = new List<GameObject>();
    public List<GameObject> playerChips2 = new List<GameObject>();

    void Start()
    {
        playerTurnManager = FindObjectOfType<PlayerTurnManager>();
    }

    public void MoveChipTo(int btnNum)
    {
        if (playerTurnManager.P1_turn)
            chipTransform = playerChips1[0].transform;
        else
            chipTransform = playerChips2[0].transform;

        targetPos = placeHolders[btnNum-1].transform.position;
        StartCoroutine("MoveToTargetPos");
    }   

    IEnumerator MoveToTargetPos()
    {
        while (Vector3.Distance(chipTransform.position, targetPos) > 0.05f)
        {
            chipTransform.position = Vector3.Lerp(chipTransform.position, targetPos, smoothing * Time.deltaTime);
            yield return null;
        }

        if (playerTurnManager.P1_turn)
            playerChips1.RemoveAt(0);
        else
            playerChips2.RemoveAt(0);
        
        playerTurnManager.SwitchPlayerTurn();
        playerTurnManager.ToggleTouchInputCover();
    }
}
