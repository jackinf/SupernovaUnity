using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject[] ElementsToHideOnPause;
    public GameObject[] ElementsToShowOnPause;

    private bool _isPaused = false;
    private float _previousTimeScale = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause(_isPaused);     // if it is paused, then unpause
        }
    }

    public void TogglePause(bool unpause)
    {
        if (unpause)
        {
            foreach (var element in ElementsToHideOnPause)
                element.SetActive(true);
            foreach (var element in ElementsToShowOnPause)
                element.SetActive(false);

            Time.timeScale = _previousTimeScale;
            _isPaused = false;
        }
        else
        {
            foreach (var element in ElementsToHideOnPause)
                element.SetActive(false);
            foreach (var element in ElementsToShowOnPause)
                element.SetActive(true);

            _previousTimeScale = Time.timeScale;
            Time.timeScale = 0;
            _isPaused = true;
        }
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1;
        Application.LoadLevel(ApplicationModel.Levels.StartMenu);
    }
}
