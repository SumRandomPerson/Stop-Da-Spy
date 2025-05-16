using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    IEnumerator RemoveTutorial()
    {
        yield return new WaitForSeconds(7);
        Destroy(gameObject);  
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("RemoveTutorial");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
