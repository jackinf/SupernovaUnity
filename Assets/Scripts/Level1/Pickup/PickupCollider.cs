using UnityEngine;

public class PickupCollider : MonoBehaviour
{
    private AudioSource pickupSound;

    void Start()
    {
        // TODO: add safety check
        var sounds = GameObject.FindGameObjectWithTag("Sounds");

        pickupSound = sounds.transform.FindChild("Pickup").GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.AddPointsForPickup();
            Destroy(transform.parent.gameObject);
            pickupSound.Play();
        }
    }
}
