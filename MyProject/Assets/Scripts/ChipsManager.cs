using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChipsManager : MonoBehaviour
{
    public delegate void DoneMovingChip();
    public static event DoneMovingChip OnFinishedMovingChip;

    [SerializeField]private GameObject[] placeHolders;
    private PlayerTurnManager playerTurnManager;
    private GameArbiter gameArbiter;
    private Transform chipTransform;
    private float smoothing = 6f;
    private Vector3 targetPos;

    public List<GameObject> playerChips = new List<GameObject>();

    void Start()
    {
        playerTurnManager = FindObjectOfType<PlayerTurnManager>();
        gameArbiter = FindObjectOfType<GameArbiter>();
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
        OnFinishedMovingChip();
        gameArbiter.CheckMatrix();
    }
}
