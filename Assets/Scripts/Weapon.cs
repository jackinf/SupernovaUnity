﻿using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;           // Projectile's template
    public float projectileSpeed = 20f;     // Speed of the projectile
    public GameObject projectileWithCenter;

    private GameObject aProjectile;         // Instantiated projectile
    private GameObject aProjectileWithCenter;         // Instantiated projectile
    private Vector3 projectileDirection;    // Direction, in which projectile moves

    private Vector3 centerPosition;         // Position around which the objects will be rotating

    public float smooth = 2.0F;
    public float tiltAngle = 30.0F;

    private float rotX = 0.1f;
    private float rotY = 0.1f;

    void Awake()
    {
        center = GameObject.FindGameObjectWithTag("Center").transform;
        centerPosition = center.position;
        axis = Vector3.up;
    }

    void Start()
    {
        //transform.position = (transform.position - center.position).normalized * radius + center.position;
        //firstRotation = transform.rotation;
        //projectileWithCenter.transform.LookAt(projectileWithCenter.transform.position);
    }

    public void Shoot(Vector3 playersPosition, Quaternion playersRotation, bool isReversed = false)
    {
        var angle = Vector3.Angle(transform.up, Vector3.up);
        Debug.Log(string.Format("Angle: {0}", angle));
        Debug.Log(string.Format("Player's rotation: {0}", playersRotation));

        //aProjectile = Instantiate(projectile, fromPosition, Quaternion.identity) as GameObject;
        aProjectileWithCenter = Instantiate(projectileWithCenter, projectileWithCenter.transform.position, transform.rotation) as GameObject;
        if (aProjectileWithCenter != null)
        {
            aProjectileWithCenter.transform.LookAt(playersPosition * -1);
            //aProjectileWithCenter.transform.rotation *= playersRotation;
        }
        reverseFactor = angle > 90f && angle < 180f ? -1 : 1;
    }

    public Transform center;
     public Vector3 axis;
     public float radius = 20.0f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 80.0f;
    private int reverseFactor = 1;
    private Quaternion firstRotation;

    private void Update()
    {
        if (aProjectile != null)
        {
            //// Test1
            //aProjectile.transform.RotateAround(centerPosition, new Vector3(10f, 10f, 0f), projectileSpeed * Time.deltaTime);
            //aProjectile.transform.Rotate(10f, 0, 0);

            //// Test2
            //Quaternion qX = Quaternion.AngleAxis(rotX * projectileSpeed * Time.deltaTime, Vector3.right);
            //Quaternion qY = Quaternion.AngleAxis(rotY * projectileSpeed * Time.deltaTime, Vector3.forward);
            ////Quaternion offset = Quaternion.Euler(0f, 5f, 5f);

            //Quaternion q = qX * qY;
            ////Rotates about the local axis
            //aProjectile.transform.rotation = q;
            ////Rotates the object around the axis in world axis
            //aProjectile.transform.position = q * aProjectile.transform.position;

            //// Test3
            //aProjectile.transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
            //var desiredPosition = (aProjectile.transform.position - center.position).normalized * radius + center.position;
            //aProjectile.transform.position = Vector3.MoveTowards(aProjectile.transform.position, desiredPosition, Time.deltaTime * radiusSpeed);

            //// Test4
            //Quaternion rotation = Quaternion.AngleAxis(projectileSpeed * Time.deltaTime, Vector3.up);
            //Quaternion offset = Quaternion.Euler(0f, 2f, 0f);
            //Quaternion combined = rotation*offset;
            ////aProjectile.transform.rotation *= rotation;
            //aProjectile.transform.position = combined*aProjectile.transform.position;

            //// Test5
            //var lookPos = center.position - transform.position;
            //lookPos.y = 0;
            //var rotation = Quaternion.LookRotation(lookPos);
            //rotation *= Quaternion.Euler(0, 90, 0); // this add a 90 degrees Y rotation
            ////var adjustRotation = transform.rotation.y + rotationAdjust; //<- this is wrong!
            //aProjectile.transform.position = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime) * aProjectile.transform.position;
        }

        if (aProjectileWithCenter != null)
        {
            //Debug.Log(string.Format("Reverse factor: {0}", reverseFactor));
            var direction = new Vector2(transform.rotation.x, transform.rotation.y) * reverseFactor;
            
            var normalizedDir = direction.normalized;
            var angleAxis = Quaternion.AngleAxis(Time.deltaTime * projectileSpeed, normalizedDir);
            aProjectileWithCenter.transform.rotation *= angleAxis;
            //aProjectileWithCenter.transform.Rotate(normalizedDir * Time.deltaTime * projectileSpeed);
        }
    }
}
