using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChipsManager : MonoBehaviour
{
    [SerializeField]private GameObject[] placeHolders;
    [SerializeField]private List<GameObject> p1chips;
    private Transform chipTransform;
    private float smoothing = 5f;
    private Vector3 targetPos;
    
    public void MoveChipTo(int btnNum)
    {
        chipTransform = p1chips[0].transform;
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
    }
}
