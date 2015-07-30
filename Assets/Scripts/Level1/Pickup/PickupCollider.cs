using UnityEngine;

/// <summary>
/// Pickup object's collider space to detect, if player got close to pickup.
/// </summary>
public class PickupCollider : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.Instance.AddPointsForPickup();
            Destroy(transform.parent.gameObject);
            SoundManager.Instance.PlayPickupSound();
        }
    }
}
