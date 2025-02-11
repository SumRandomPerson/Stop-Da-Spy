using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PauseScreen : MonoBehaviour
{
    public UnityEngine.UI.Button resumeButton;
    public UnityEngine.UI.Button quitButton;
    public UnityEngine.UI.Button settingsButton;
    public UnityEngine.UI.Button backButton;

    public GameObject pauseMenu;
    private MainMenu gameManager;
    

    bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        MainMenu mainMenu = GameObject.Find("Game Manager").GetComponent<MainMenu>();
        resumeButton.onClick.AddListener(Unpause);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            Debug.Log("P");
            if(paused)
            {
                Unpause();
            }else
            {
                Pause();
            }
            
        }
    }

    void Pause()
    {

        Time.timeScale = 0;
        paused = true;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void Unpause()
    {

        Time.timeScale = 1;
        paused = false;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
