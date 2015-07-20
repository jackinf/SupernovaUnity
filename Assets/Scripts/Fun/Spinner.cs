using UnityEngine;

public class Spinner : MonoBehaviour 
{
    void Update()
    {
        //var rot = Quaternion.AngleAxis(300f, Vector3.up);
        var rot = Quaternion.Euler(new Vector3(1f, 0f, 1f));
        transform.rotation *= rot;
        transform.position = rot*transform.position;
    }
}
