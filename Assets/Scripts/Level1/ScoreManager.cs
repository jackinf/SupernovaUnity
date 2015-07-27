using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text UiAsteroidText;
    public Text UiScoreText;

    private static int asteroidsDestroyed = 0;
    private static int score = 0;
    private static bool updateText = false;

    public static void AddPointsForAsteroid()
    {
        asteroidsDestroyed++;
        score += ApplicationModel.AsteroidPoints;
        updateText = true;
    }

    public static void AddPointsForPickup()
    {
        score += ApplicationModel.PickupPoints;
        updateText = true;
    }

    void Update()
    {
        if (updateText)
        {
            updateText = false;
            UiAsteroidText.text = "Asteroids: " + asteroidsDestroyed + "/∞";
            UiScoreText.text = "Score: " + score;
        }
    }
}
