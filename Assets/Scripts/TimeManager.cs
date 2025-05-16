using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public bool isStopped = false;
    public bool stopCooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine("StartCooldownTimer");
        ToggleTime();
    }
    IEnumerator StartCooldownTimer()
    {
        yield return new WaitForSeconds(7);
        stopCooldown = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e")&& stopCooldown == false)
        {
            ToggleTime();
            StartCoroutine("StartTimer");
            stopCooldown = true;
        }
    }
    public void ToggleTime()
    {
        isStopped = !isStopped;
    }
}
