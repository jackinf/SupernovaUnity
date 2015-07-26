using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEngine.UI;

public class ShipSelectionManager : MonoBehaviour {

    public GameObject[] ships;
    public int pointerId;
    public Text shipsName;

    void Awake()
    {
        transform.gameObject.SetActive(EditorApplication.currentScene.Split('/').Last() == ApplicationModel.SelectShipSceneName);
    }

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
