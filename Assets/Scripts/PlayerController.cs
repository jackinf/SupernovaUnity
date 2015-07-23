using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject center;           // point to rotate around
    public float speed = 3;             // movement speed

    private Weapon weapon;

    void Awake()
    {
        weapon = GetComponent<Weapon>();
    }

    void Update()
    {
        // Draw local coordinates
        Debug.DrawLine(transform.position, transform.position + transform.forward*10, Color.blue);
        Debug.DrawLine(transform.position, transform.position + transform.up*10, Color.green);
        Debug.DrawLine(transform.position, transform.position + transform.right*10, Color.red);

        // Movement logic
        RotateUsingQuaternions();

        // Shooting logic
        Shooting();
    }

    private void RotateUsingQuaternions()
    {
        // Get input
        var horizontal = Input.GetAxis("HorizontalMovement");
        var vertical = Input.GetAxis("VerticalMovement");

        // Calculate the axis to move around. We calculate 90-degree vector in order to move up when pressing UP key, not right.
        // This way, we calculate 2D Vector, which always makes an 90-degree angle to the player-s front.
        // We use this Vector to rotate our player around.

        var axis = new Vector2(vertical, -horizontal);

        if (axis != Vector2.zero)
        {
            axis.Normalize();      // Convert X and Y values, which should be between 0 and 1.
            Debug.DrawLine(axis * -30f, axis * 30f, Color.cyan);
            var angleAxis = Quaternion.AngleAxis(Time.deltaTime * speed, axis);     // Calculate the rotation.
            center.transform.localRotation *= angleAxis;    // Apply the rotation to the player.
        }
    }

    private void Shooting()
    {
        // Shooting section
        var horizontalShoot = Input.GetAxis("HorizontalShoot");
        var verticalShoot = Input.GetAxis("VerticalShoot");
        var shootDirection = new Vector3(horizontalShoot, 0, verticalShoot);
        shootDirection.Normalize();
        if (Math.Abs(horizontalShoot) > float.Epsilon || Math.Abs(verticalShoot) > float.Epsilon)
        {
            var transformedShootingDirection = transform.TransformDirection(shootDirection);     // transform from local space to world space
            weapon.Shoot(transform.position, transform.position + transformedShootingDirection);
            Debug.DrawLine(transform.position, transform.position + transformedShootingDirection * 10f, Color.white);
        }
    }

}
