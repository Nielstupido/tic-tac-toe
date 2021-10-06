using UnityEngine;
using Photon.Pun;

public class GameArbiter : MonoBehaviourPunCallbacks
{
    [SerializeField]private GameObject winnerWindow;
    [SerializeField]private GameObject winnerBoard;
    private GameEndManager gameEndManager;
    private int[,] tableMatrix = new int[3,3];
    private int buttonNum;
    private int winnerNum;
    private bool isWinner = false;

    public int ButtonNumPressed { set {buttonNum = value; MarkMatrix(); } }
    public int WinnerNum { get{return winnerNum;}}

    void Start()
    {
        gameEndManager = FindObjectOfType<GameEndManager>();
    }

    void MarkMatrix()
    {
        switch (buttonNum)
        {
            case 1:
                tableMatrix[0,0] = 1;
                break;
            
            case 2:
                tableMatrix[0,1] = 1;
                break;
            
            case 3:
                tableMatrix[0,2] = 1;
                break;
            
            case 4:
                tableMatrix[1,2] = 1;
                break;
            
            case 5:
                tableMatrix[1,1] = 1;
                break;
            
            case 6:
                tableMatrix[1,0] = 1;
                break;
            
            case 7:
                tableMatrix[2,0] = 1;
                break;
            
            case 8:
                tableMatrix[2,1] = 1;
                break;
            
            case 9:
                tableMatrix[2,2] = 1;
                break;
        }
    }


    public void CheckMatrix()
    {
        if (tableMatrix[0,0] == 1 && tableMatrix[0,1] == 1 && tableMatrix[0,2] ==1)
        {
            isWinner = true;
        }
        else if (tableMatrix[1,0] == 1 && tableMatrix[1,1] == 1 && tableMatrix[1,2] ==1)
        {
            isWinner = true;
        }
        else if (tableMatrix[2,0] == 1 && tableMatrix[2,1] == 1 && tableMatrix[2,2] ==1)
        {
            isWinner = true;
        }
        else if (tableMatrix[0,0] == 1 && tableMatrix[1,0] == 1 && tableMatrix[2,0] ==1)
        {
            isWinner = true;
        }
        else if (tableMatrix[0,1] == 1 && tableMatrix[1,1] == 1 && tableMatrix[2,1] ==1)
        {
            isWinner = true;
        }
        else if (tableMatrix[0,2] == 1 && tableMatrix[1,2] == 1 && tableMatrix[2,2] ==1)
        {
            isWinner = true;
        }
        else if (tableMatrix[0,0] == 1 && tableMatrix[1,1] == 1 && tableMatrix[2,2] ==1)
        {
            isWinner = true;
        }
        else if (tableMatrix[0,2] == 1 && tableMatrix[1,1] == 1 && tableMatrix[2,0] ==1)
        {
            isWinner = true;
        }

        if (isWinner)
        {
            photonView.RPC("AnnounceWinner", RpcTarget.All, PlayerPrefs.GetInt("PlayerNum"));
        }
        else if (gameEndManager.TotalMoves == 6)
        {
            //enable restricted movement
        }
    }

    [PunRPC]
    void AnnounceWinner(int playerNum)
    {
        winnerNum = playerNum;
        winnerWindow.SetActive(true);
        winnerBoard.SetActive(true);
    }
}
