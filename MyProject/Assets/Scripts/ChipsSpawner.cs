using UnityEngine;
using Photon.Pun;

public class ChipsSpawner : MonoBehaviour
{
   [SerializeField]private GameObject chipPrefab;

    void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            PhotonNetwork.Instantiate(chipPrefab.name, Vector3.zero, Quaternion.identity);
        }
    }
}
