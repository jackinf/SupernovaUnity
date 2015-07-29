using UnityEngine;

public class AsteroidCollider : MonoBehaviour
{
    public GameObject AsteroidExplosionTemplate;
    public GameObject PlayerExplosionTemplate;
    public float HitPoints = 100;

    private AudioSource _asteroidHitSound;
    private AudioSource _explosionSound;
    private AudioSource _deathSound;

    void Start()
    {
        // TODO: add safety check
        var sounds = GameObject.FindGameObjectWithTag("Sounds");

        _asteroidHitSound = sounds.transform.FindChild("AsteroidHit").GetComponent<AudioSource>();
        _explosionSound = sounds.transform.FindChild("Explosion").GetComponent<AudioSource>();
        _deathSound = sounds.transform.FindChild("Death").GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            var bulletDamage = other.gameObject.GetComponent<BulletDamage>().Damage;
            HitPoints -= bulletDamage;

            if (HitPoints <= 0)
            {
                PickupManager.pickupLocations.Enqueue(transform.position);
                ScoreManager.AddPointsForAsteroid();
                Destroy(transform.parent.gameObject);   // destroy asteroid's wrapper GameObject
                _explosionSound.Play();
            }
            else
            {
                _asteroidHitSound.Play();
            }

            Destroy(Instantiate(AsteroidExplosionTemplate, transform.position, Quaternion.identity), 3f);       // play explosion
            Destroy(other.gameObject);                  // bullet should be destroyed anyways
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            Destroy(Instantiate(PlayerExplosionTemplate, transform.position, Quaternion.identity), 3f);         // play explosion
            other.gameObject.SetActive(false);          // We do not destroy the player as he needs to reappear. Instead, we disable it.
            _deathSound.Play();
            RespawnManager.StartRespawn(other.gameObject);
        }
    }
}
