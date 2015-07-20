using UnityEngine;

public class Looker : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        var rot = Quaternion.LookRotation(target.transform.position, Vector3.up);
        transform.rotation = rot;
    }
}
