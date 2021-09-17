using UnityEngine;
using Photon.Pun;

public class ChipsSpawner : MonoBehaviour
{
    [SerializeField]private GameObject chipPrefab;
    private ChipsManager chipsManager;
    private GameObject chip;

    void Start()
    {
        chipsManager = FindObjectOfType<ChipsManager>();
        
        for (int i = 0; i < 3; i++)
        {
            chip = (GameObject)PhotonNetwork.Instantiate(chipPrefab.name, Vector3.zero, Quaternion.identity, 0);
            chipsManager.playerChips.Add(chip);
        }
    }
}
