using UnityEngine;

public class ChangeShip : MonoBehaviour
{
    public CurrentShip currentShipScript;

    public void ShowNext(bool isNext)
    {
        currentShipScript.SetNextShip(isNext);
    }
}
