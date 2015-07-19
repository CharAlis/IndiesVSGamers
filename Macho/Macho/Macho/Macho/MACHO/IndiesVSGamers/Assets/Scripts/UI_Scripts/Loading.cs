using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Loading : MonoBehaviour {
    public string nextLevel = "Menu";
    
	private Color col;

	void Start () {
		col = GetComponent<Image>().color;
		col.a = 0;
		GetComponent<Image>().color = col;
        StartCoroutine(LoadNextLevel(nextLevel));
	}


	IEnumerator FadeIn( float duration ) {
		for( float a = 0f; a < 1f; a += Time.deltaTime/duration) {
			col = GetComponent<Image>().color;
			col.a = a;
			GetComponent<Image>().color = col;
			yield return null;
		}
		yield return null;
	}

	IEnumerator FadeOut( float duration ) {
		for( float a = 1f; a > 0f; a -= Time.deltaTime/duration) {
			col = GetComponent<Image>().color;
			col.a = a;
			GetComponent<Image>().color = col;
			yield return null;
		}
		yield return null;
	}


    IEnumerator LoadNextLevel(string name) {
		yield return StartCoroutine(FadeIn(2f));
        yield return new WaitForSeconds(3f);
		yield return StartCoroutine(FadeOut(2f));
        Application.LoadLevel(name);
    }
}
