using UnityEngine;

public class StartTheGame : MonoBehaviour 
{
    public void ShowShipSelectionMenu()
    {
        Application.LoadLevel(1);
    }

    public void LoadLevelOne()
    {
        Application.LoadLevel(2);
    }

    public void ShowOptionsMenu()
    {
        Debug.Log("Showing options menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
