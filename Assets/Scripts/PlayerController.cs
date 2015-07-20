using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject center;
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
        // Get input
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        // Calculate the axis to move around. We calculate 90-degree vector in order to move up when pressing UP key, not right.
        // This way, we calculate 2D Vector, which always makes an 90-degree angle to the player-s front.
        // We use this Vector to rotate our player around.

        var axis = new Vector2(vertical, -horizontal);

        if (axis != Vector2.zero)
        {
            axis.Normalize();      // Convert X and Y values, which should be between 0 and 1.
            var angleAxis = Quaternion.AngleAxis(Time.deltaTime * speed, axis);     // Calculate the rotation.
            center.transform.localRotation *= angleAxis;    // Apply the rotation to the player.
        }
    }

}
