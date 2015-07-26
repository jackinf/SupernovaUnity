using UnityEngine;

[SerializeField]
public abstract class Orbiteer
{
    public GameObject gameObject;

    protected Transform chilTransform;
    protected float movementSpeed = 10f;
    protected Vector3 localRotation = Vector3.zero;
    protected bool isOrbiting = true;

    protected Orbiteer(GameObject gameObject)
    {
        this.gameObject = gameObject;
        chilTransform = this.gameObject.transform.GetChild(0);

        if (chilTransform == null)
            Debug.LogError("Orbiteer should have a game object with parent game object");
    }

    public bool IsAlive()
    {
        return gameObject != null;
    }

    public virtual void Update()
    {
        if (!IsAlive())
            return;

        if (isOrbiting)
        {
            var qR = Quaternion.AngleAxis(Time.deltaTime * movementSpeed, Vector3.right);       // calculate the rotation around X (=right) axis
            gameObject.transform.rotation *= qR;                                                // apply the rotation

            if (chilTransform != null)
                chilTransform.Rotate(localRotation);
        }
    }
}