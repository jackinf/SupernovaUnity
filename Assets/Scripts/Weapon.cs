using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float projectileSpeed = 20f;         // Speed of the projectile
    public GameObject projectileTemplate;       // Projectile's template

    private GameObject projectileClone;         // Instantiated projectile
    
    private void Update()
    {
        if (projectileClone != null)
        {
            var axis = Vector3.right;                       // axis around which are projectiles going to rotate. Projectile's direction is 90 degrees CCW
            var qR = Quaternion.AngleAxis(Time.deltaTime * projectileSpeed, axis);      // calculate the rotation around axis
            projectileClone.transform.rotation *= qR;       // apply the rotation
        }
    }

    /// <summary>
    /// Instantiates projectiles
    /// </summary>
    /// <param name="fromPosition">Position, where projectiles start flying from</param>
    /// <param name="forward">Direction to shoot projectiles towards</param>
    public void Shoot(Vector3 fromPosition, Vector3 forward)
    {
        if (projectileClone != null)
            Destroy(projectileClone);

        // We use LookAt to instantiate projetiles on the right place. Projectiles should be comprised from 2 parts: center point and GameObject
        // which rotates around its center. GameObject is on the surface of the planet.
        // We also need -1 for projectiles to appear not on the other side of the planet. 

        projectileTemplate.transform.LookAt(fromPosition * -1, forward);         
        //projectileClone = Instantiate(projectileTemplate, projectileTemplate.transform.position, transform.rotation) as GameObject;
        projectileClone = Instantiate(projectileTemplate);
    }
}
