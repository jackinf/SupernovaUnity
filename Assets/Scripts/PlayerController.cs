using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public GameObject Center;
    public float speed = 3;

    private Weapon weapon;

    void Awake()
    {
        weapon = GetComponent<Weapon>();
    }

    void Update()
    {
        RotateUsingQuaternions();

        if (Input.GetButtonDown("Fire1"))
        {
            weapon.Shoot(transform.position, Input.mousePosition);
        }
    }

    private void RotateUsingQuaternions()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var direction = new Vector2(vertical, -horizontal);

        if (direction != Vector2.zero)
        {
            var normalizedDir = direction.normalized;
            var angleAxis = Quaternion.AngleAxis(Time.deltaTime * speed, normalizedDir);
            Center.transform.rotation *= angleAxis;
        }
    }

    private void RotateUsingVectors()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        //RotateMe();

        if (Mathf.Abs(horizontal) > 0)
        {
            transform.RotateAround(Center.transform.position, IsReversed() ? Vector3.up : Vector3.down, horizontal * speed * Time.deltaTime);
        }

        if (Mathf.Abs(vertical) > 0)
        {
            transform.RotateAround(Center.transform.position, Vector3.left, vertical * speed * Time.deltaTime);
        }
    }

    private bool IsReversed()
    {
        var angle = Vector3.Angle(transform.up, Vector3.up);
        Debug.Log(angle);
        return angle > 90f;
    }
    

}
