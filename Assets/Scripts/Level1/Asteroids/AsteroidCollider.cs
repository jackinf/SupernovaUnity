using UnityEngine;

public class AsteroidCollider : MonoBehaviour
{
    public GameObject AsteroidExplosionTemplate;
    public GameObject PlayerExplosionTemplate;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(Instantiate(AsteroidExplosionTemplate, transform.position, Quaternion.identity), 3f);       // play explosion
            PickupManager.pickupLocations.Enqueue(transform.position);
            Destroy(transform.parent.gameObject);
            Destroy(other.gameObject);
            ScoreManager.AddPointsForAsteroid();
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            Destroy(Instantiate(PlayerExplosionTemplate, transform.position, Quaternion.identity), 3f);         // play explosion
            other.gameObject.SetActive(false);          // We do not destroy the player as he needs to reappear. Instead, we disable it.
            //GameObject.FindGameObjectWithTag("RespawnManager").GetComponent<RespawnManager>().StartRespawn(other.gameObject);
            RespawnManager.StartRespawn(other.gameObject);
        }
    }
}
