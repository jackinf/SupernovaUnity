using UnityEngine;

public class RespawnManager: MonoBehaviour
{
    private static float _respawnTimeout = 3f;
    private static float _respawnTimePassed;
    private static bool _isRespawning;
    private static GameObject _objectToRespawn;

    void Update()
    {
        if (!_isRespawning)
            return;

        _respawnTimePassed += Time.deltaTime;
        if (_respawnTimeout < _respawnTimePassed)
        {
            _objectToRespawn.SetActive(true);
            _isRespawning = false;
        }
    }

    public static void StartRespawn(GameObject objectToRespawn, float respawnTimeout = 3f)
    {
        _respawnTimePassed = 0;
        _objectToRespawn = objectToRespawn;
        _respawnTimeout = respawnTimeout;
        _isRespawning = true;
    }
}
