using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    private int enemyCount;
    private bool levelFinished = false; 
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if(enemyCount <= 0 && levelFinished == false)
        {
            levelFinished = true;
            StartCoroutine("SceneTransition");
        }
    }
    IEnumerator SceneTransition()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Level 2");
        
    }
}
