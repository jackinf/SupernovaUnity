using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectileTemplate;                                           // Projectile's template
    public float projectileSpeed = 200f / ApplicationModel.Planet1Radius;           // Speed of the bullet
    public BulletManager bulletManager;
    public AudioSource shootingClip;

    private float shootTreshold = .1f;      // shooting interval
    private float shootingTimePassed;       // when this value is less than shootTreshold then weapon cannot shoot

    void Update()
    {
        shootingTimePassed += Time.deltaTime;
    }

    /// <summary>
    /// Instantiates projectiles
    /// </summary>
    /// <param name="fromPosition">Position, where projectiles start flying from</param>
    /// <param name="shootDirection">Direction in which to shoot projectiles</param>
    public void Shoot(Vector3 fromPosition, Vector3 shootDirection)
    {
        if (shootingTimePassed > shootTreshold)
        {
            shootingTimePassed = 0;

            // We use LookAt to instantiate projetiles on the right place. Projectiles should be comprised from 2 parts: center point and GameObject
            // which rotates around its center. GameObject is on the surface of the planet.
            // We also need -1 for projectiles to appear not on the other side of the planet. 
            projectileTemplate.transform.LookAt(fromPosition * -1, fromPosition * -1 + shootDirection);

            // Let's create a bullet and add it to the pool.
            var bullet = new Bullet(Instantiate(projectileTemplate), projectileSpeed);
            bulletManager.Add(bullet);
            shootingClip.Play();
        }
    }
}
