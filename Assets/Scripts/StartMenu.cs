using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public string ItchUrl;

    public void StartGame()
    {
        SceneManager.LoadScene("0-1");
    }
    public void LevelSeclect()
    {
        SceneManager.LoadScene("Level Select");
    }
    public void Open()
    {
        Application.OpenURL(ItchUrl);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
