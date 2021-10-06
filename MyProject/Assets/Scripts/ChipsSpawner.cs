using UnityEngine;
using Photon.Pun;

public class ChipsSpawner : MonoBehaviour
{
    [SerializeField]private GameObject chipPrefab;
    private GameObject chip;

    void Start()
    {
        
        for (int i = 0; i < 3; i++)
        {
            chip = (GameObject)PhotonNetwork.Instantiate(chipPrefab.name, Vector3.zero, Quaternion.identity, 0);
        }
    }
}
