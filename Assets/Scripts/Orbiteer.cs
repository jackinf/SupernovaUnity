using UnityEngine;

public class Orbiteer : MonoBehaviour
{
    public GameObject projectile;           // Projectile's template
    private GameObject aProjectile;         // Instantiated projectile

    private Transform objectToOrbit; //Object To Orbit
    private Vector3 orbitAxis = Vector3.up; //Which vector to use for Orbit
    private float orbitRadius = 20f; //Orbit Radius
    private float orbitRadiusCorrectionSpeed = 0.5f; //How quickly the object moves to new position
    private float orbitRoationSpeed = 200.0f; //Speed Of Rotation arround object
    private float orbitAlignToDirectionSpeed = 0.5f; //Realign speed to direction of travel

    private Vector3 orbitDesiredPosition;
    private Vector3 previousPosition;
    private Vector3 relativePos;
    private Quaternion rotation;
    private Transform thisTransform;

    //---------------------------------------------------------------------------------------------------------------------

    private void Awake()
    {
        objectToOrbit = GameObject.FindGameObjectWithTag("Center").transform;
    }

    //---------------------------------------------------------------------------------------------------------------------

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(transform.position);
        }

        if (aProjectile != null)
        {
            //Movement
            thisTransform.RotateAround(objectToOrbit.position, orbitAxis, orbitRoationSpeed * Time.deltaTime);
            orbitDesiredPosition = (thisTransform.position - objectToOrbit.position).normalized * orbitRadius +
                                   objectToOrbit.position;
            thisTransform.position = Vector3.Slerp(thisTransform.position, orbitDesiredPosition,
                Time.deltaTime * orbitRadiusCorrectionSpeed);

            //Rotation
            relativePos = thisTransform.position - previousPosition;
            rotation = Quaternion.LookRotation(relativePos);
            thisTransform.rotation = Quaternion.Slerp(thisTransform.rotation, rotation,
                orbitAlignToDirectionSpeed * Time.deltaTime);
            previousPosition = thisTransform.position;
        }

    }

    public void Shoot(Vector3 fromPosition)
    {
        aProjectile = Instantiate(projectile, fromPosition, Quaternion.identity) as GameObject;
        thisTransform = aProjectile.transform;
    }
}