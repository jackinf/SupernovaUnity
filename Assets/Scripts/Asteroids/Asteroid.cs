using UnityEngine;

public class Asteroid
{
    public readonly GameObject go;
    public float movementSpeed = 10f;
    public float descendSpeed = .5f;
    public float startDescendingDistance = 50f;
    public float descendMaximumDistance = 21f;

    private readonly Vector3 _localRotation = Vector3.one;
    private readonly Transform chilTransform;
    private bool _isDescending = true;
    private bool _isOrbiting = false;

    public Asteroid(GameObject gameObject)
    {
        go = gameObject;
        chilTransform = go.transform.GetChild(0);
        chilTransform.position = new Vector3(chilTransform.position.x, chilTransform.position.y, startDescendingDistance * -1);
    }

    public Asteroid(GameObject gameObject, float movementSpeed, Vector3 localRotation) : this(gameObject)
    {
        this.movementSpeed = movementSpeed;
        _localRotation = localRotation;
    }

    public void Update()
    {
        if (!IsAlive())
            return;

        if (_isOrbiting)
        {
            var qR = Quaternion.AngleAxis(Time.deltaTime * movementSpeed, Vector3.right);       // calculate the rotation around axis
            go.transform.rotation *= qR;                                                // apply the rotation
            chilTransform.Rotate(_localRotation);
        }

        if (_isDescending)
        {
            var distanceToCenter = Vector3.Distance(go.transform.position, chilTransform.position);
            if (distanceToCenter <= descendMaximumDistance)
            {
                _isDescending = false;
                _isOrbiting = true;
            }
            else
            {
                chilTransform.position = Vector3.MoveTowards(chilTransform.position, go.transform.position, descendSpeed);
            }
        }
    }

    public bool IsAlive()
    {
        return go != null;
    }
}
