using UnityEngine;

public class AsteroidInner : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
