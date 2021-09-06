using UnityEngine;
using Photon.Pun;

public class ChipsSpawner : MonoBehaviour
{
   [SerializeField]private GameObject chipPrefab;
   [SerializeField]private GameObject chipParent1;
   [SerializeField]private GameObject chipParent2;
   private ChipsManager chipsManager;

    void Start()
    {
        chipsManager = FindObjectOfType<ChipsManager>();

        for (int i = 0; i < 3; i++)
        {
            GameObject chip = PhotonNetwork.Instantiate(chipPrefab.name, Vector3.zero, Quaternion.identity);
            chipsManager.playerChips.Add(chip);
        }
    }
}
