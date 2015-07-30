using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ShipSelectionManager : MonoBehaviour {

    public GameObject[] ships;
    public int pointerId;
    public Text shipsName;

    void Start ()
	{
        SetSingleShipActive(pointerId);
	}

    public void SetNextShip(bool forward)
    {
        var shipsCount = ships.Count();
        Helpers.GetNextPointer(ref pointerId, shipsCount);
        SetSingleShipActive(pointerId);
    }

    private void SetSingleShipActive(int which)
    {
        var shipsCount = ships.Count();
        if (shipsCount < 0)
            Debug.LogError(ApplicationModel.Errors.NoShipsDefined);

        for (int i = 0; i < shipsCount; i++)
        {
            if (which == i)
            {
                ships[i].SetActive(true);
                ApplicationModel.CurrentShipName = ships[i].name;
                shipsName.text = ships[i].name;
            }
            else
            {
                ships[i].SetActive(false);                
            }
        }
    }
}
