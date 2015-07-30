using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text UiAsteroidText;
    public Text UiScoreText;
    public Slider BottomSlider;

    private static int asteroidsDestroyed = 0;
    private static int score = 0;
    private static int sliderValue = 0;
    private static bool updateHudElements = false;

    void Awake()
    {
        if (BottomSlider != null)
        {
            BottomSlider.minValue = ApplicationModel.SliderMinValue;
            BottomSlider.maxValue = ApplicationModel.SliderMaxValue;            
        }
    }

    public static void AddPointsForAsteroid()
    {
        asteroidsDestroyed++;
        score += ApplicationModel.AsteroidPoints;
        updateHudElements = true;
        sliderValue += ApplicationModel.SliderStep;
    }

    public static void AddPointsForPickup()
    {
        score += ApplicationModel.PickupPoints;
        updateHudElements = true;
        sliderValue += ApplicationModel.SliderStep;
    }

    void Update()
    {
        if (updateHudElements)
        {
            updateHudElements = false;
            UiAsteroidText.text = "Asteroids: " + asteroidsDestroyed + "/∞";
            UiScoreText.text = "Score: " + score;
            if (BottomSlider != null)
                BottomSlider.value = Mathf.Clamp(sliderValue, 0, 100);
        }
    }
}
