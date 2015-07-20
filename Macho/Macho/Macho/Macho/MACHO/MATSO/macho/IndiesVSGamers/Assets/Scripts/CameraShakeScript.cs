using UnityEngine;
using System.Collections;

public class CameraShakeScript : MonoBehaviour {

	private Camera mainCam;
	public static CameraShakeScript Instance;
	float shakeAmount = 0;

	// Use this for initialization
	void Awake () {
		Instance = this;
		mainCam = Camera.main;
	}
	
	public void Shake(float amount, float length)
	{
		shakeAmount = amount;
		InvokeRepeating("BeginShake", 0, 0.01f);
		Invoke("StopShake", length);
	}

	public void BeginShake () {
		if (shakeAmount > 0)
		{
			Vector3 camPos = mainCam.transform.position;

			float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
			float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
			camPos.x += offsetX;
			camPos.y += offsetY;

			mainCam.transform.position = camPos;
		}
	}

	public void StopShake()
	{
		CancelInvoke("BeginShake");
		mainCam.transform.localPosition = new Vector3(0,5.64f,-10);
	}
}
