using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManualControl : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Controls");
    }
    public void Next()
    {
        SceneManager.LoadScene("About");
    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
