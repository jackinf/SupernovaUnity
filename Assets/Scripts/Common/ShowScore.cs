using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Component for displaying score.
/// </summary>
public class ShowScore : MonoBehaviour
{
    public Text TextElement;

    void Awake()
    {
        TextElement.text = "Highscore: " + ScoreManager.GetScore();
    }
}
