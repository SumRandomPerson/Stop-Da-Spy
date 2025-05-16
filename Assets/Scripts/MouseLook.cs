using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform player;
    private float tilt = 0f;
    
    public float baseSensitivity = 1;
    private PauseScreen pauseMenu;
    float xRotation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.Find("Game Manager").GetComponent<PauseScreen>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float sens = pauseMenu.sensitvitySlider.value*baseSensitivity;
        float mouseX = Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90,90);

        transform.localRotation = Quaternion.Euler(xRotation,0.0f,tilt);
        player.Rotate(Vector3.up * mouseX);
    }
    public void SetTilt(float t)
    {
        tilt = t;
    }
     public float GetTilt()
    {
        return tilt;
    }
}
