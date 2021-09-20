using UnityEngine;

public class GameArbiter : MonoBehaviour
{
    private int[,] tableMatrix = new int[3,3];
    private int buttonNum;

    public int AddMark { set {buttonNum = value;}}

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


    void CheckMatrix()
    {
        
    }
}
