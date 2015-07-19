using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

	public static Manager Instance;
	private int razors = 3;
	private int grenades = 3;
	private float floatscore = 0;
	private int intscore = 0;
	private GameObject razorimages;
	private Image[] imgs;
	private Text score;

	void Awake()
	{
		Instance = this;
		imgs = new Image[9];
		razorimages = GameObject.Find("Razors");
		int i = 0;
		foreach (Transform t in razorimages.transform)
		{
			imgs[i] = t.GetComponent<Image>();
			++i;
		}
		score = GameObject.Find("Score").GetComponent<Text>();
	}

	// Use this for initialization
	void Start ()
	{
		imgs[3].enabled = imgs[4].enabled = false;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		floatscore += Time.deltaTime * MovingPlatform.Instance.speed * 2;
		intscore = (int)floatscore;
		score.text = intscore.ToString();
	}

	public void LoseRazor()
	{
		if (razors > 0)
		{
			razors--;
			imgs[razors].enabled = false;
		}
		else if (razors == 0)
		{
			GameOver();
		}
		Brockontroller.Instance.EmitHearts();
		CameraShakeScript.Instance.Shake(0.1f, 0.1f);
	}

	public void GetRazor()
	{
		if (razors < 5)
		{
			razors++;
			imgs[razors].enabled = true;
		}
	}

	public void GetGrenade()
	{
		if (grenades < 3)
		{
			grenades++;
			imgs[5 + grenades].enabled = true;
		}
	}

	public void GameOver()
	{
		PauseGame.Instance.GameOver();
	}

	public void AddScore(int quantity)
	{
		floatscore += quantity;
	}
}
