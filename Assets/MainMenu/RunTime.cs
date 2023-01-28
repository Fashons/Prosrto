using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunTime : MonoBehaviour
{
    public void PlayPressed()
    {
            SceneManager.LoadScene("1Level");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
}
