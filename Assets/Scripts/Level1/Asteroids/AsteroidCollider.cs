using UnityEngine;

/// <summary>
/// Used for detecting collisions to asteroid.
/// </summary>
public class AsteroidCollider : MonoBehaviour
{
    public GameObject AsteroidExplosionTemplate;
    public GameObject PlayerExplosionTemplate;
    public float HitPoints = 100;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            OnBulletImpact(other);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            OnPlayerImpact(other);
        }
    }

    /// <summary>
    /// What happens if a colliders is a bullet?
    /// </summary>
    /// <param name="other"></param>
    private void OnBulletImpact(Collider other)
    {
        var bulletDamage = other.gameObject.GetComponent<BulletDamage>().Damage;
        HitPoints -= bulletDamage;

        if (HitPoints <= 0)
        {
            PickupManager.Instance.DropPickup(transform.position);
            ScoreManager.Instance.AddPointsForAsteroid();
            Destroy(transform.parent.gameObject);   // destroy asteroid's wrapper GameObject
            SoundManager.Instance.PlayExplosionSound();
        }
        else
        {
            SoundManager.Instance.PlayHitSound();
        }

        Destroy(Instantiate(AsteroidExplosionTemplate, transform.position, Quaternion.identity), 3f);       // play explosion
        Destroy(other.gameObject);                  // bullet should be destroyed anyways
    }

    /// <summary>
    /// What happens if a colliders is a player?
    /// </summary>
    /// <param name="other"></param>
    private void OnPlayerImpact(Collider other)
    {
        Destroy(Instantiate(PlayerExplosionTemplate, transform.position, Quaternion.identity), 3f);         // play explosion
        other.gameObject.SetActive(false);          // We do not destroy the player as he needs to reappear. Instead, we disable it.
        SoundManager.Instance.PlayDeathSound();
        RespawnManager.Instance.StartRespawn(other.gameObject);
    }
}
