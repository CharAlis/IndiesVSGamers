using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour 
{
    public GameObject pauseCanvas;
    public GameObject exitC;
	public GameObject gameOverCanvas;
	public static PauseGame Instance;
    public bool pauseGame = false;
    public bool resumePressed = false;
	public static bool isPaused = false;
	public bool gameOvered = false;
    
	void Awake()
	{
		Instance = this;
	}
	
	void Update()
    {
		isPaused = pauseGame;
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOvered)
        {
            pauseGame = !pauseGame;
            if (pauseGame)
            {
                pauseCanvas.SetActive(true);
                Time.timeScale = 0;
				Cursor.visible = true;
            }

            if (pauseGame == false)
            {
                pauseCanvas.SetActive(false);
				exitC.SetActive(false);
                Time.timeScale = 1;
				Cursor.visible = false;
            }
        }
    }

    public void Resume()
    {
        pauseGame = false;
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
		Cursor.visible = false;
    }

	public void GameOver()
	{
		gameOverCanvas.SetActive(true);
		pauseGame = true;
		Time.timeScale = 0;
		Cursor.visible = true;
		gameOvered = true;
	}
}
