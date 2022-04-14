using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScreen : MonoBehaviour
{
    // Start is called before the first frame update

    public void MainReturn()
    {
        SceneManager.LoadScene("Start Screen");
    }
    public void Level01()
    {
        SceneManager.LoadScene("0-1");
    }
    public void Level02()
    {
        SceneManager.LoadScene("0-2");
    }
    public void Level03()
    {
        SceneManager.LoadScene("0-3");
    }
    public void Level04()
    {
        SceneManager.LoadScene("0-4");
    }
}
