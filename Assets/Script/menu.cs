using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{

    public string play, setting;
    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene(play);
    }

    public void Setting()
    {
        SceneManager.LoadScene(setting);
    }

}
