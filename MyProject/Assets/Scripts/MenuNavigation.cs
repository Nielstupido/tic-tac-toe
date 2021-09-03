using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    public void CloseGame()
    {
        Application.Quit();
    }

    public void OpenLobby()
    {
        Debug.Log("dfsdf");
        SceneManager.LoadScene("Loading");
    }
}
