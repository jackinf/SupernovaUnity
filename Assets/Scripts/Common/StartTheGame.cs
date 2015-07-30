using UnityEngine;

/// <summary>
/// Uses LevelManager logic
/// </summary>
public class StartTheGame : MonoBehaviour 
{
    public void ShowShipSelectionMenu()
    {
        LevelManager.GoToShipSelectionMenu();
    }

    public void LoadLevelOne()
    {
        LevelManager.GoToLevel(ApplicationModel.Levels.Level1);
    }

    public void GoToNextLevel()
    {
        LevelManager.GoToNextLevel();
    }

    public void RetryCurrentLevel()
    {
        LevelManager.RetryCurrentLevel();
    }

    public void GoToMainMenu()
    {
        LevelManager.GoToMainMenu();
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
