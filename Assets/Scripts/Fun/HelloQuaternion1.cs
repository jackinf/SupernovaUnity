using UnityEngine;

public class HelloQuaternion1 : MonoBehaviour 
{
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var target = Quaternion.Euler(horizontal, 0, vertical);
        //transform.rotation *= target;
        //transform.position = target*transform.position;
        transform.Translate(new Vector3(horizontal, 0f, vertical));
    }
}
