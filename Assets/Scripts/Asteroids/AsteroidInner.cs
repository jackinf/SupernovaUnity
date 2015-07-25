using UnityEngine;

public class AsteroidInner : MonoBehaviour
{
    public GameObject explosionTemplate;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Instantiate(explosionTemplate, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
