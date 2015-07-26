using UnityEngine;

public class ChangeShip : MonoBehaviour
{
    public ShipSelectionManager shipSelectionManagerScript;

    public void ShowNext(bool isNext)
    {
        shipSelectionManagerScript.SetNextShip(isNext);
    }
}
