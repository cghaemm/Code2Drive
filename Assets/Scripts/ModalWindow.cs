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

    private Animator anim;

    [SerializeField] private GameObject restart_button;
    [SerializeField] private GameObject next_button;
    [SerializeField] private TextMeshProUGUI headingText;
    [SerializeField] private TextMeshProUGUI modalText;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        modalText.text = "TESTING";
        anim = gameObject.GetComponent<Animator>();
    }

    public void finishedLevel()
    {
        headingText.text = "CONGRATULATIONS!";
        modalText.text = "You reached your goal safely!";
        gameObject.SetActive(true);
        anim.SetTrigger("PopUp");
        restart_button.SetActive(false);
        next_button.SetActive(true);
    }

    public void playerCrashed()
    {
        headingText.text = "CRASHED!";
        modalText.text = "You crashed your car!";
        lost();
    }

    public void playerOffroad()
    {
        headingText.text = "CRASHED!";
        modalText.text = "You drove off the road!";
        lost();
    }

    public void gameOver() // Use this function when player does not finish
    {
        headingText.text = "FAILED!";
        modalText.text = "You ran out of gas and didn't reach the goal!";
        lost();
    }
    
    public void lost()
    {
        gameObject.SetActive(true);
        anim.SetTrigger("PopUp");
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
