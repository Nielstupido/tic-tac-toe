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

    public List<GameObject> playerChips = new List<GameObject>();

    void Start()
    {
        playerTurnManager = FindObjectOfType<PlayerTurnManager>();
    }

    public void MoveChipTo(int btnNum)
    {
        chipTransform = playerChips[0].transform;

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

        playerChips.RemoveAt(0);
        
        playerTurnManager.ToggleSwitchPlayer();
        playerTurnManager.ToggleTouchInputCover();
    }
}
