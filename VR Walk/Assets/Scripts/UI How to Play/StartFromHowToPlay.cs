using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartFromHowToPlay : MonoBehaviour {
    private string SceneName = "Main Backup";

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
