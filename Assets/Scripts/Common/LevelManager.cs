using UnityEngine;

/// <summary>
/// Changes levels or shows specific scenes. Static.
/// </summary>
public static class LevelManager
{
    /// <summary>
    /// Repeat a level, where player was last time
    /// </summary>
    public static void RetryCurrentLevel()
    {
        Application.LoadLevel(ApplicationModel.Levels.CurrentLevel);
    }

    /// <summary>
    /// Proceed to the next level according to the array of all levels.
    /// </summary>
    public static void GoToNextLevel()
    {
        int nextLevelIndex = ApplicationModel.Levels.levels.IndexOf(ApplicationModel.Levels.CurrentLevel) + 1;
        ApplicationModel.Levels.CurrentLevel = ApplicationModel.Levels.levels[nextLevelIndex];        // next level becomes current level
        Application.LoadLevel(ApplicationModel.Levels.CurrentLevel);
    }

    /// <summary>
    /// Manually specify the level to load. (TODO: Maybe indices are not the best way to do it...)
    /// </summary>
    /// <param name="level"></param>
    public static void GoToLevel(int level)
    {
        ApplicationModel.Levels.CurrentLevel = level;
        Application.LoadLevel(level);
    }

    /// <summary>
    /// Go to the starting menu.
    /// </summary>
    public static void GoToMainMenu()
    {
        ApplicationModel.Levels.CurrentLevel = ApplicationModel.Levels.StartMenu;
        Application.LoadLevel(ApplicationModel.Levels.CurrentLevel);
    }

    /// <summary>
    /// Go to the menu, where player can select himself a spaceship.
    /// </summary>
    public static void GoToShipSelectionMenu()
    {
        ApplicationModel.Levels.CurrentLevel = ApplicationModel.Levels.ShipSelectionMenu;
        Application.LoadLevel(ApplicationModel.Levels.CurrentLevel);        
    }

    /// <summary>
    /// Show losing screen
    /// </summary>
    public static void Lose()
    {
        Application.LoadLevel(ApplicationModel.Levels.YouLost);
    }

    /// <summary>
    /// Show winning screen
    /// </summary>
    public static void Win()
    {
        Application.LoadLevel(ApplicationModel.Levels.YouWin);
    }

}
