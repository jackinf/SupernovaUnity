using System.Collections;
using UnityEngine;

/// <summary>
/// Manager, which brings e.g. player back to the game
/// </summary>
public class RespawnManager: Singleton<RespawnManager>
{
    protected RespawnManager() { }

    private GameObject _objectToRespawn;

    /// <summary>
    /// Begin the process of bringing the player back to the game.
    /// </summary>
    /// <param name="objectToRespawn"></param>
    /// <param name="respawnTimeout"></param>
    public void StartRespawn(GameObject objectToRespawn, float respawnTimeout = 3f)
    {
        _objectToRespawn = objectToRespawn;

        StartCoroutine(RespawnInProgress(respawnTimeout));
    }

    /// <summary>
    /// Coroutine process.
    /// </summary>
    /// <param name="respawnTimeout">How long to wait</param>
    /// <returns></returns>
    IEnumerator RespawnInProgress(float respawnTimeout)
    {
        yield return new WaitForSeconds(respawnTimeout);

        _objectToRespawn.SetActive(true);
    }
}
