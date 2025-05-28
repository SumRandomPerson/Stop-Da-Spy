using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public bool isStopped = false;
    public bool stopCooldown = false;
    public AudioClip timestopSound;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = timestopSound;
    }
    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine("StartCooldownTimer");
        ToggleTime();
        audio.pitch = 2f;
        audio.Play();
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
            audio.pitch = 1f;
            audio.Play();
        }
    }
    public void ToggleTime()
    {
        isStopped = !isStopped;
    }
}
