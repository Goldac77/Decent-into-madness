using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameoverscript : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
