using UnityEngine;

public class StartTheGame : MonoBehaviour 
{
    public void ShowShipSelectionMenu()
    {
        Application.LoadLevel(ApplicationModel.Levels.ShipSelectionMenu);
    }

    public void LoadLevelOne()
    {
        Application.LoadLevel(ApplicationModel.Levels.Level1);
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
