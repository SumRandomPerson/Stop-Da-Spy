using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public UnityEngine.UI.Button playButton;
    public UnityEngine.UI.Button quitButton;
    public UnityEngine.UI.Button settingsButton;
    public UnityEngine.UI.Button backButton;
    public Slider audioSlider;
    
    public GameObject settingsMenu;
    public GameObject titleScreen;

    float audioValue = 0.5f;

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
        audioValue = audioSlider.value;
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


