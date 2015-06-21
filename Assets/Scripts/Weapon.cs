using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;           // Projectile's template
    public float projectileSpeed = 50f;     // Speed of the projectile

    private GameObject aProjectile;         // Instantiated projectile
    private GameObject aProjectileCenter;   // Point, around which is instantiated projetile rotating
    private Vector3 projectileDirection;    // Direction, in which projectile moves

    private Vector3 centerPosition;         // Position around which the objects will be rotating

    void Awake()
    {
        centerPosition = GameObject.FindGameObjectWithTag("Center").transform.position;
        //centerPosition = new Vector3();
    }

    public void Shoot(Vector3 fromPosition, Vector3 mouseClick)
    {
        var screenCenter = new Vector3(x: Screen.width / 2f, y: Screen.height / 2f, z: 0f);
        projectileDirection = new Vector3(mouseClick.y - screenCenter.y, screenCenter.x - mouseClick.x, 0f).normalized;
        
        //Debug.Log(string.Format("Mouse click: {0}", mouseClick));
        //Debug.Log(string.Format("From position: {0}", fromPosition));
        //Debug.Log(string.Format("Projectile direction: {0}", projectileDirection));

        aProjectileCenter = new GameObject();
        aProjectileCenter.transform.position = centerPosition;
        aProjectileCenter.transform.rotation = Quaternion.identity;
        Debug.Log(aProjectileCenter.transform.position);
        Debug.Log(aProjectileCenter.transform.rotation);

        aProjectile = Instantiate(projectile, fromPosition, Quaternion.identity) as GameObject;

        if (aProjectile == null)
        {
            Debug.LogError("A projectile was not instantiated!");
        }
        else
        {
            aProjectile.transform.parent = aProjectileCenter.transform;
        }
    }

    private void Update()
    {
        if (aProjectile != null)
        {
            //aProjectile.transform.RotateAround(centerPosition, Vector3.up, Time.deltaTime * projectileSpeed);
            //aProjectile.transform.Translate(projectileDirection * projectileSpeed * Time.deltaTime);
            var angleAxis = Quaternion.AngleAxis(Time.deltaTime * projectileSpeed, projectileDirection);
            aProjectileCenter.transform.rotation *= angleAxis;
        }
    }
}
