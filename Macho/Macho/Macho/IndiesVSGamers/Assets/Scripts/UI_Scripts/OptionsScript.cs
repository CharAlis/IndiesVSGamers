using UnityEngine;
using System.Collections;

public class OptionsScript : MonoBehaviour 
{
    public GameObject exitCanvas;
    public GameObject pauseCanvas;

    public void ExitButton(GameObject exit)
    {
        pauseCanvas.SetActive(false);
        exitCanvas.SetActive(true);
    }

    public void NoButton(GameObject no)
    {
        pauseCanvas.SetActive(true);
        exitCanvas.SetActive(false);
    }

    public void YesButton(GameObject yes)
    {
        Application.Quit();
    }
	
	public void Retry()
	{
		Time.timeScale = 1;
		PauseGame.Instance.gameOvered = false;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void GameOverExit()
	{
		Application.LoadLevel(1);
	}
}
