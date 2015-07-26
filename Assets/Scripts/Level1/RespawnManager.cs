using UnityEngine;

public class RespawnManager: MonoBehaviour
{
    public float respawnTimeout = 3f;
    public float respawnTimePassed;

    private bool _isRespawning;
    private GameObject _objectToRespawn;

    void Update()
    {
        if (!_isRespawning)
            return;

        respawnTimePassed += Time.deltaTime;
        if (respawnTimeout < respawnTimePassed)
        {
            _objectToRespawn.SetActive(true);
            _isRespawning = false;
        }
    }

    public void StartRespawn(GameObject objectToRespawn, float respawnTimeout = 3f)
    {
        respawnTimePassed = 0;
        _objectToRespawn = objectToRespawn;
        this.respawnTimeout = respawnTimeout;
        _isRespawning = true;
    }
}
