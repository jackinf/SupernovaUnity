using UnityEngine;

public class ApplicationModel : MonoBehaviour
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
    }

    public class Errors
    {
        public static string NoShipsDefined = "There are no ships defined";
    }
}
