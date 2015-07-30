using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Calculates player's accumulated score.
/// </summary>
public class ScoreManager : Singleton<ScoreManager>
{
    protected ScoreManager() { }

    public Text UiAsteroidText;
    public Text UiScoreText;
    public Slider BottomSlider;

    private int _asteroidsDestroyed = 0;
    private static int _score = 0;
    private int _bottomSliderValue = 0;
    private bool _updateHudElements = false;

    protected override void Awake()
    {
        base.Awake();

        if (BottomSlider != null)
        {
            BottomSlider.minValue = ApplicationModel.SliderMinValue;
            BottomSlider.maxValue = ApplicationModel.SliderMaxValue;            
        }
    }

    public void AddPointsForAsteroid()
    {
        _asteroidsDestroyed++;
        _score += ApplicationModel.AsteroidPoints;
        _updateHudElements = true;
        _bottomSliderValue += ApplicationModel.SliderStep;
    }

    public void AddPointsForPickup()
    {
        _score += ApplicationModel.PickupPoints;
        _updateHudElements = true;
        _bottomSliderValue += ApplicationModel.SliderStep;
    }

    void FixedUpdate()
    {
        if (_updateHudElements)
        {
            _updateHudElements = false;
            UiAsteroidText.text = "Asteroids: " + _asteroidsDestroyed + "/∞";
            UiScoreText.text = "Score: " + _score;
            if (BottomSlider != null)
                BottomSlider.value = Mathf.Clamp(_bottomSliderValue, 0, 100);
        }
    }

    public static int GetScore()
    {
        var score = _score;
        _score = 0;
        return score;
    }
}
