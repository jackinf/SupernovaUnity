using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float projectileSpeed = 20f;         // Speed of the projectile
    public GameObject projectileTemplate;       // Projectile's template

    private GameObject projectileClone;         // Instantiated projectile

    public void Shoot(Vector3 playersPosition, Vector3 up)
    {
        projectileClone = Instantiate(projectileTemplate, projectileTemplate.transform.position, transform.rotation) as GameObject;
        if (projectileClone != null)
            projectileClone.transform.LookAt(playersPosition*-1, up);   // -1 is needed for projectiles to appear not on the other side of the planet
    }

    private void Update()
    {
        if (projectileClone != null)
        {
            var axis = Vector3.right;                       // axis around which are projectiles going to rotate. Projectile's direction is 90 degrees CCW
            var qR = Quaternion.AngleAxis(Time.deltaTime * projectileSpeed, axis);      // calculate the rotation around axis
            projectileClone.transform.rotation *= qR;       // apply the rotation
        }
    }
}
