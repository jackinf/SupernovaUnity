using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

// TODO: put into other place
public class VecQuat
{
    public Vector3 position;
    public Quaternion rotation;
}

public class PickupManager : MonoBehaviour
{
    public GameObject pickupCenterTemplate;
    public static Queue<VecQuat> pickupLocations = new Queue<VecQuat>();
    
    private readonly List<Pickup> _pickups = new List<Pickup>();

    public void DropPickup(VecQuat pos)
    {
        var random = new Random();
        if (random.Next(0, 2) == 0)
        {
            var go = Instantiate(pickupCenterTemplate);
            go.transform.rotation = pos.rotation;
            go.transform.GetChild(0).position = pos.position;
            var pickup = new Pickup(go);
            _pickups.Add(pickup);
        }
    }

    void FixedUpdate()
    {
        for (int i = 0; i < pickupLocations.Count; i++)
            DropPickup(pickupLocations.Dequeue());

        for (int i = _pickups.Count - 1; i >= 0; i--)
        {
            var pickup = _pickups[i];
            if (!pickup.IsAlive())
            {
                _pickups.RemoveAt(i);
                continue;
            }

            pickup.UpdateInner();
        }
    }
}
