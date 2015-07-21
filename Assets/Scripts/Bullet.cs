using UnityEngine;

[SerializeField]
public class Bullet
{
    private GameObject gameObject;
    private readonly float speed;

    public Bullet(GameObject gameObject, float speed = 200f)
    {
        this.gameObject = gameObject;
        this.speed = speed;
    }

    //[HideInInspector]
    public void OuterUpdate()
    {
        if (gameObject != null)
        {
            // Vector3.right is axis around which are projectiles going to rotate. Projectile's direction is 90 degrees CCW.

            var qR = Quaternion.AngleAxis(Time.deltaTime * speed, Vector3.right);       // calculate the rotation around axis
            gameObject.transform.rotation *= qR;                                        // apply the rotation
        }
    }

    public bool IsAlive()
    {
        return gameObject != null;
    }

}
