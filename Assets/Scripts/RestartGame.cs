using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }

   public void Quit()
    {

        Application.Quit();
    }
}
