using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using TMPro;

public class ModalWindow : MonoBehaviour
{

    // In Java, final = const
    private const int MAIN_MENU_INDEX = 0;

    [SerializeField] private GameObject restart_button;
    [SerializeField] private GameObject next_button;
    [SerializeField] private TextMeshProUGUI headingText;
    [SerializeField] private TextMeshProUGUI modalText;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        modalText.text = "TESTING";
    }

    public void finishedLevel()
    {
        // Add changing text here later
        gameObject.SetActive(true);
        restart_button.SetActive(false);
        next_button.SetActive(true);
    }

    public void playerCrashed()
    {
        // Add functions to change text later
        lost();
        headingText.text = "CRASHED!";
    }

    public void playerOffroad()
    {
        // Add functions to change text later
        lost();
    }

    public void gameOver() // Use this function when player does not finish
    {
        // Add functions to change text later
        lost();
    }
    
    public void lost()
    {
        gameObject.SetActive(true);
        restart_button.SetActive(true);
        next_button.SetActive(false);
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
