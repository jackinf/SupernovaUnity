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
        // Movement logic
        RotateUsingQuaternions();

        // Shooting logic
        if (Input.GetButtonDown("Jump"))
            weapon.Shoot(transform.position, transform.forward);

        // Rotation logic
        var leftButton = Input.GetButton("RotateLeft");
        var rightButton = Input.GetButton("RotateRight");
        if (leftButton || rightButton)
        {
            transform.Rotate(0f, 270 * Time.deltaTime * (leftButton ? -1 : 1), 0f);
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
            Center.transform.localRotation *= angleAxis;
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
