using UnityEngine;
using System.Collections;

public class ActivateParticles : MonoBehaviour {

	void Start()
	{
		foreach(Transform t in transform)
		{
			t.GetComponent<ParticleSystem>().Emit(10);
		}
	}

}
