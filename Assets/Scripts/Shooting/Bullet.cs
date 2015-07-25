using UnityEngine;

public class Bullet : Orbiteer
{
    public Bullet(GameObject gameObject, float speed = 200f) : base(gameObject)
    {
        this.movementSpeed = speed;
    }

}
