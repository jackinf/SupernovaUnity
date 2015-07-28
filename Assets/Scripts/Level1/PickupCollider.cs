using UnityEngine;

public class PickupCollider : MonoBehaviour 
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.AddPointsForPickup();
            Destroy(transform.parent.gameObject);
        }
    }
}
