using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Debug.Log("level" + name);
        Brick.breakableCount = 0;
        Application.LoadLevel(name);
    }
    public void QuitReq()
    {
        Debug.Log("lemme Quit");
        Application.Quit();
    }
    public void LoadNextLevel()
    {
         Brick.breakableCount = 0;
        Application.LoadLevel(Application.loadedLevel + 1);

    }
    public void BrickDestroyed()
    {

        if (Brick.breakableCount<=0)
        {
            LoadNextLevel();
        }
    }

}
