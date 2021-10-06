using UnityEngine;
using System.Collections;

public class ChipsManager : MonoBehaviour
{
    public delegate void DoneMovingChip();
    public static event DoneMovingChip OnFinishedMovingChip;

    private PlayerTurnManager playerTurnManager;
    private GameArbiter gameArbiter;
    private Transform chipTransform;
    private float smoothing = 6f;
    private Vector3 targetPos;

    void Start()
    {
        playerTurnManager = FindObjectOfType<PlayerTurnManager>();
        gameArbiter = FindObjectOfType<GameArbiter>();
    }

    public void MoveChipTo(GameObject pressedButton, GameObject selectedChip)
    {
        chipTransform = selectedChip.transform;
        targetPos = pressedButton.transform.position;
        StartCoroutine("MoveToTargetPos");
    }   

    IEnumerator MoveToTargetPos()
    {
        while (Vector3.Distance(chipTransform.position, targetPos) > 0.05f)
        {
            chipTransform.position = Vector3.Lerp(chipTransform.position, targetPos, smoothing * Time.deltaTime);
            yield return null;
        }

        gameArbiter.CheckMatrix();
        OnFinishedMovingChip();
    }
}
