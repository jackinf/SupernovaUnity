using UnityEngine;

public class Asteroid : Orbiteer
{
    public float descendSpeed = .5f;
    public float startDescendingDistance = 50f;
    public float descendMaximumDistance = ApplicationModel.Planet1Radius;

    public bool _isDescending = true;

    public Asteroid(GameObject gameObject) : base(gameObject)
    {
        chilTransform.position = new Vector3(chilTransform.position.x, chilTransform.position.y, startDescendingDistance * -1);
        isOrbiting = false;
    }

    public Asteroid(GameObject gameObject, float movementSpeed, Vector3 localRotation) : this(gameObject)
    {
        this.movementSpeed = movementSpeed;
        this.localRotation = localRotation;
    }

    public override void Update()
    {
        base.Update();

        if (!IsAlive())
            return;

        if (_isDescending)
        {
            var distanceToCenter = Vector3.Distance(gameObject.transform.position, chilTransform.position);
            if (distanceToCenter <= descendMaximumDistance)
            {
                _isDescending = false;
                isOrbiting = true;
            }
            else
            {
                chilTransform.position = Vector3.MoveTowards(chilTransform.position, gameObject.transform.position, descendSpeed);
            }
        }
    }

}
