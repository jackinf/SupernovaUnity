using UnityEngine;

public class Pickup : Orbiteer
{
    public Pickup(GameObject gameObject) : base(gameObject)
    {
        isOrbiting = true;
    }
}
