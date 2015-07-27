using UnityEngine;

public class PickupCollider : MonoBehaviour 
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pickup trigger");
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.AddPointsForPickup();
            Destroy(transform.parent.gameObject);
        }
    }
}
