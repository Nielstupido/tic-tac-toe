using UnityEngine;

public class GameArbiter : MonoBehaviour
{
    [SerializeField] private GameObject winnerWindow;
    private int[,] tableMatrix = new int[3,3];
    private int buttonNum;
    private int winnerNum;

    public int ButtonNumPressed { set {buttonNum = value; MarkMatrix(); } }

    public int WinnerNum { get{return winnerNum;}}

    void OnDisable()
    {
        ChipsManager.OnFinishedMovingChip -= AnnounceWinner;   
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

        }
        else if (tableMatrix[1,0] == 1 && tableMatrix[1,1] == 1 && tableMatrix[1,2] ==1)
        {

        }
        else if (tableMatrix[2,0] == 1 && tableMatrix[2,1] == 1 && tableMatrix[2,2] ==1)
        {

        }
        else if (tableMatrix[0,0] == 1 && tableMatrix[1,0] == 1 && tableMatrix[2,0] ==1)
        {

        }
        else if (tableMatrix[0,1] == 1 && tableMatrix[1,1] == 1 && tableMatrix[2,1] ==1)
        {
            
        }
        else if (tableMatrix[0,2] == 1 && tableMatrix[1,2] == 1 && tableMatrix[2,2] ==1)
        {

        }
        else if (tableMatrix[0,0] == 1 && tableMatrix[1,1] == 1 && tableMatrix[2,2] ==1)
        {

        }
        else if (tableMatrix[0,2] == 1 && tableMatrix[1,1] == 1 && tableMatrix[2,0] ==1)
        {

        }
        winnerNum = PlayerPrefs.GetInt("PlayerNum");
    }

    void AnnounceWinner()
    {
        winnerWindow.SetActive(true);
    }
}
