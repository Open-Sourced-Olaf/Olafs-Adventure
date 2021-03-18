using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeControl : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
