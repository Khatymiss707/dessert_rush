using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class main_menu : MonoBehaviour
{
    public void PlayGame()
    {
      SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
       Application.Quit();
    }

    public void GoBack()
    {
        SceneManager.LoadScene("menu");
    }
}
