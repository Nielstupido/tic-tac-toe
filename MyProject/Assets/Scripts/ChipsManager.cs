using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChipsManager : MonoBehaviour
{
    [SerializeField]private GameObject[] placeHolders;
    [SerializeField]private List<GameObject> p1chips;
    [SerializeField]private List<GameObject> p2chips;
    private Transform chipTransform;
    private float smoothing = 5f;
    private Vector3 targetPos;
    private bool p1_turn = true;

    public bool P1_turn { set {p1_turn = value;} }
    
    public void MoveChipTo(int btnNum)
    {
        if (p1_turn)
            chipTransform = p1chips[0].transform;
        else
            chipTransform = p2chips[0].transform;

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

        if (p1_turn)
            p1chips.RemoveAt(0);
        else
            p2chips.RemoveAt(0);
    }
}
