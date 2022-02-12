using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Debug.Log("level" + name);
        Application.LoadLevel(name);
    }
    public void QuitReq()
    {
        Debug.Log("lemme Quit");
        Application.Quit();
    }
}
