using UnityEngine;

public class AsteroidInner : MonoBehaviour
{
    public GameObject explosionTemplate;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            PlayExplosion();
            Destroy(gameObject.transform.parent.gameObject);
            Destroy(other.gameObject);
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
