using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver: MonoBehaviour {
    public void Setup(bool val) {
        gameObject.SetActive(val);
    }

    public void RestartButton() {
        SceneManager.LoadScene("level1");
    }

    public void Home() {
        SceneManager.LoadScene("Menu");
    }
}