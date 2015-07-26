using UnityEngine;

public static class Helpers
{
    public static void Reset(this GameObject gameObject)
    {
        gameObject.transform.position = Vector3.zero;
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}