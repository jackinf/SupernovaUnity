using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject center;           // point to rotate around
    public float speed = 3;             // movement speed
    public int lives = 3;
    public GameObject shipModels;       // contains all ship models

    private Weapon _weapon;
    private SphereCollider _collisionDetector;
    private MeshRenderer _meshRenderer;
    private const int BlinkCount = 10;

    void Awake()
    {
        _weapon = GetComponent<Weapon>();
        _collisionDetector = GetComponent<SphereCollider>();
        SetSelectedShipModel();
        ScoreManager.SetLives(lives);
        //_meshRenderer = gameObject.transform.GetChild(0).GetComponent<MeshRenderer>();
    }

    void OnEnable()
    {
        SetInvincible(true);
        StartCoroutine(InvincibleAndBlink());
    }

    void OnDisable()
    {
        if (ScoreManager.Instance != null)
            ScoreManager.SetLives(--lives);
    }

    void FixedUpdate()
    {
        // Draw local coordinates
        Debug.DrawLine(transform.position, transform.position + transform.forward * 10, Color.blue);
        Debug.DrawLine(transform.position, transform.position + transform.up * 10, Color.green);
        Debug.DrawLine(transform.position, transform.position + transform.right * 10, Color.red);
    }

    void Update()
    {
        // Movement logic
        RotateUsingQuaternions();

        // Shooting logic
        Shooting();

        if (lives <= 0)
        {
            LevelManager.Lose();
        }
    }

    /// <summary>
    /// Here, the ship's 3D model is set. 
    /// </summary>
    private void SetSelectedShipModel()
    {
        Transform selectedShip = null;        // Get selected ship model by name
        for (int i = shipModels.transform.childCount - 1; i >= 0; i--)
        {
            var potentialShipModel = shipModels.transform.GetChild(i);
            if (potentialShipModel.name == ApplicationModel.CurrentShipName)
                selectedShip = potentialShipModel;
            else
                Destroy(potentialShipModel.gameObject);
        }

        if (selectedShip == null)
        {
            Debug.LogError("Ship with " + ApplicationModel.CurrentShipName + " was not found");
            return;
        }

        selectedShip.gameObject.SetActive(true);
        selectedShip.parent = gameObject.transform;                             // Assign a new parent
        _meshRenderer = selectedShip.GetComponent<MeshRenderer>();              // Set the mesh, which will be blinking, rotating etc
        Destroy(shipModels);                                                    // We don't need this container anymore. By this time, it should be empty anyways.
    }

    /// <summary>
    /// Player's movement logic. Movement is done using rotations around the planet.
    /// </summary>
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

    /// <summary>
    /// Direction vector to shoot is calculated.
    /// </summary>
    private void Shooting()
    {
        var horizontalShoot = Input.GetAxis("HorizontalShoot");
        var verticalShoot = Input.GetAxis("VerticalShoot");
        var shootDirection = new Vector3(horizontalShoot, 0, verticalShoot);
        shootDirection.Normalize();
        if (Math.Abs(horizontalShoot) > float.Epsilon || Math.Abs(verticalShoot) > float.Epsilon)
        {
            var transformedShootingDirection = transform.TransformDirection(shootDirection);     // transform from local space to world space for correct shooting direction
            _weapon.Shoot(transform.position, transform.position + transformedShootingDirection);
            Debug.DrawLine(transform.position, transform.position + transformedShootingDirection * 10f, Color.white);   // Draws a vector in which direction the shooting occurs
            // TODO: Add turret rotation
        }
    }

    /// <summary>
    /// Can anybody kill the player?
    /// </summary>
    /// <param name="value">Invincible or not?</param>
    public void SetInvincible(bool value)
    {
        _collisionDetector.enabled = !value;
    }

    /// <summary>
    /// Coroutine method. Player is invincible during the whole coroutine and he blinks.
    /// </summary>
    /// <returns>Wait interval</returns>
    private IEnumerator InvincibleAndBlink()
    {
        int counter = 0;
        while (counter < BlinkCount)
        {
            counter++;
            _meshRenderer.enabled = !_meshRenderer.enabled;
            yield return new WaitForSeconds(.1f);
        }

        SetInvincible(false);

        yield return null;
    }

}
