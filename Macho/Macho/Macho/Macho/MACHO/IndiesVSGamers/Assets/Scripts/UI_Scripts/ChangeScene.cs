using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour 
{
    public void ChangeLevel(int sceneLevel)
    {
        Application.LoadLevel(sceneLevel);
    }
}
