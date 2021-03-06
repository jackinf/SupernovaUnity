﻿using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

/// <summary>
/// Manager, which is capable of instantiating pickups and updating them to orbit around the planet.
/// </summary>
public class PickupManager : Singleton<PickupManager>
{
    protected PickupManager() { }

    public GameObject pickupCenterTemplate;
    //public Queue<Vector3> pickupLocations = new Queue<Vector3>();
    public float dropChance = .33f;
    
    private readonly List<Pickup> _pickups = new List<Pickup>();

    /// <summary>
    /// Instantiate a pickup on position.
    /// </summary>
    /// <param name="pos"></param>
    public void DropPickup(Vector3 pos)
    {
        var random = new Random();
        if (random.NextDouble() < dropChance)
        {
            var go = Instantiate(pickupCenterTemplate);
            go.transform.GetChild(0).position = pos;
            var pickup = new Pickup(go);
            _pickups.Add(pickup);
        }
    }

    void FixedUpdate()
    {
        //for (int i = 0; i < pickupLocations.Count; i++)
        //    DropPickup(pickupLocations.Dequeue());

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
