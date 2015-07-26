using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour
{
	void Update () {
	    transform.Rotate(Vector3.up, 30f * Time.deltaTime, Space.Self);
	}
}
