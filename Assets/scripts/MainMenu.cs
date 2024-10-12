using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GameData.lives = 3;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scene1");
        }
    }
}