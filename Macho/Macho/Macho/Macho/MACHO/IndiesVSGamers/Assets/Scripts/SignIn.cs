using UnityEngine;
using System.Collections;

public class SignIn : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameJolt.UI.Manager.Instance.ShowSignIn((bool success) => {
            if (success) {
                Debug.Log("The user signed in!");
            } else {
                Debug.Log("The user failed to sign in or closed the window :(");
            }
        });
	}
}
