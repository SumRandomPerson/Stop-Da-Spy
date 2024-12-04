using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UnityEngine.UI.Button playButton;
    public UnityEngine.UI.Button quitButton;
    public UnityEngine.UI.Button settingsButton;
    public UnityEngine.UI.Button backButton;
    
    public GameObject settingsMenu;
    public GameObject titleScreen;

    bool paused = false;
    

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(EndGame);
        settingsButton.onClick.AddListener(OpenSettings);
        backButton.onClick.AddListener(CloseSettings);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartGame()
    {
        SceneManager.LoadScene("Level0");
    }
    void OpenSettings()
    {
        titleScreen.SetActive(false);
        settingsMenu.SetActive(true);
        
    }
    void CloseSettings()
    {
        titleScreen.SetActive(true);
        settingsMenu.SetActive(false);
        
    }
    void EndGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}


