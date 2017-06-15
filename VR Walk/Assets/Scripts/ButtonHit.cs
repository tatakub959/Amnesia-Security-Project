using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Just action when hit button, add to the main canvas and then drag canvas to the onclick flied of that button
public class ButtonHit : MonoBehaviour {

    public void LoadNewScene()
    {
        SceneManager.LoadScene(0);
    }
}
