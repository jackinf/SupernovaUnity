using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class CurrentShip : MonoBehaviour {

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

        pointerId = forward ? pointerId + 1 : pointerId - 1;
        pointerId = pointerId == shipsCount ? 0 : pointerId <= -1 ? shipsCount - 1 : pointerId;

        SetSingleShipActive(pointerId);
    }

    private void SetSingleShipActive(int which)
    {
        var shipsCount = ships.Count();
        if (shipsCount < 0)
            Debug.LogError("There are no ships defined");

        for (int i = 0; i < ships.Count(); i++)
        {
            if (which == i)
            {
                ships[i].SetActive(true);
                ApplicationModel.currentShip = ships[i];
                shipsName.text = ships[i].name;
            }
            else
            {
                ships[i].SetActive(false);                
            }
        }
    }
}
