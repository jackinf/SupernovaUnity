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
    public Text UiLivesText;
    public Slider BottomSlider;

    private static string _objectiveText = "";
    private static int _score = 0;
    private static int _lives = 0;
    private int _bottomSliderValue = 0;
    private static bool _updateHudElements = false;

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
        _score += ApplicationModel.AsteroidPoints;
        _updateHudElements = true;
        _bottomSliderValue += ApplicationModel.SliderStep;
    }

    public void AddPointsForPickup()
    {
        _score += ApplicationModel.PickupPoints;
        _updateHudElements = true;
    }

    /// <summary>
    /// TODO: To UiManager 
    /// </summary>
    void FixedUpdate()
    {
        if (_updateHudElements)
        {
            _updateHudElements = false;
            UiAsteroidText.text = _objectiveText;
            UiScoreText.text = "Score: " + _score;
            UiLivesText.text = "Lives: " + _lives;
            if (BottomSlider != null)
                BottomSlider.value = Mathf.Clamp(_bottomSliderValue, 0, 100);
        }
    }

    ////////////////////////////////
    // When switching scenes, singleton instance is destroyed and we need to get score back.
    // Score is stored statically.

    /// <summary>
    /// Set player's lives.
    /// TODO: To UiManager
    /// </summary>
    /// <param name="lives"></param>
    public static void SetLives(int lives)
    {
        _lives = lives > 0 ? lives : 0;
        _updateHudElements = true;
    }

    /// <summary>
    /// When level is finished, we need to get score back.
    /// TODO: Rename to GetScoreAndReset()
    /// </summary>
    /// <returns></returns>
    public static int GetScore()
    {
        var score = _score;
        _score = 0;
        return score;
    }

    /// <summary>
    /// TODO: To UiManager 
    /// </summary>
    /// <param name="objectiveText"></param>
    public static void SetTargetAsteroids(string objectiveText)
    {
        _objectiveText = objectiveText;
        _updateHudElements = true;
    }
}
