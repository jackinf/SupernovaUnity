using UnityEngine;

/// <summary>
/// Do not remove object from scene even if we switch scenes.
/// </summary>
public class DontDestroy : MonoBehaviour 
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
