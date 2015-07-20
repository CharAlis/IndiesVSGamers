using UnityEngine;
using System.Collections;

public class SortingScript : MonoBehaviour {

	void Awake()
	{
		transform.GetComponent<Renderer>().sortingOrder = 5;
	}
}
