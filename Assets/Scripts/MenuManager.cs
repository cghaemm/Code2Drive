using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public GameObject mainMenu;

    public GameObject howToPlayMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        howToPlayMenu.SetActive(false);
    }

    public void StartGame()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }


}
