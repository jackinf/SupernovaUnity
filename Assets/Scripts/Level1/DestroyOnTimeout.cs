using UnityEngine;

public class DestroyOnTimeout : MonoBehaviour
{
    public float timeout = 3f;

    void Start()
    {
        Destroy(gameObject, timeout);
    }

}
