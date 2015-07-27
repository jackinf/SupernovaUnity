using UnityEngine;

public class AsteroidCollider : MonoBehaviour
{
    public GameObject explosionTemplate;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            PlayExplosion();
            PickupManager.pickupLocations.Enqueue(new VecQuat{position = transform.position, rotation = transform.parent.rotation});
            Destroy(transform.parent.gameObject);
            Destroy(other.gameObject);
            ScoreManager.AddPointsForAsteroid();
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            PlayExplosion();
            other.gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("RespawnManager").GetComponent<RespawnManager>().StartRespawn(other.gameObject);
        }
    }

    private void PlayExplosion()
    {
        Destroy(Instantiate(explosionTemplate, gameObject.transform.position, Quaternion.identity), 3f);
    }
}
