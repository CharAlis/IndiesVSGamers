using UnityEngine;
using System.Collections;

public class ActivateParticles : MonoBehaviour {

	public void Activate()
	{
		foreach(Transform t in transform)
		{
			t.GetComponent<ParticleSystem>().Emit(10);
		}
	}

}
