using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModalWindow : MonoBehaviour
{

    // In Java, final = const
    private const int MAIN_MENU_INDEX = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void restartLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU_INDEX);
    }
}
