using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    public Button SettingsButton;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playButton.onClick.AddListener(StartGame);
    }
    void StartGame()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Level 0"));
    }
}
