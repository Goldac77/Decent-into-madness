using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startmenuscript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
