using System.Collections.Generic;

/// <summary>
/// Holds constants.
/// </summary>
public static class ApplicationModel
{
    public static float SliderMinValue = 0f;
    public static float SliderMaxValue = 100f;
    public static string CurrentShipName = "Ufo";
    public const int SliderStep = 1;
    public const int PickupPoints = 100;
    public const int AsteroidPoints = 50;
    public const string SelectShipSceneName = "spaceship_select.unity";
    public const float Planet1Radius = 30f;

    public class Levels
    {
        public const int StartMenu = 0;
        public const int ShipSelectionMenu = 1;
        public const int Level1 = 2;
        public const int Level2 = 0;        // Temp...
        public const int YouWin = 3;
        public const int YouLost = 4;

        public static int CurrentLevel = Level1;

        // All levels. Order is Important
        public static readonly List<int> levels = new List<int>
        {
            Level1,
            Level2
        };

    }

    public class Errors
    {
        public static string NoShipsDefined = "There are no ships defined";
    }
}
