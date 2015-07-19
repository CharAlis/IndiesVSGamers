using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

    public Transform[] backgrounds;
    private float[] parallaxScales;
    public float smoothing = 1f;

    void Start() {

        parallaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; ++i) {
            parallaxScales[i] = backgrounds[i].position.z * (-1);
        }
    }
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < backgrounds.Length; ++i) {
            // MovingPlatform.Instance.speed
            // backgrounds[i].transform.Translate(Vector3.left * Time.deltaTime * parallaxScales[i]);
            backgrounds[i].GetComponent<Renderer>().material.mainTextureOffset -= new Vector2( ( MovingPlatform.Instance.speed * Time.deltaTime ) / ( 10 * parallaxScales[i] ), 0);
        }
	}
}
