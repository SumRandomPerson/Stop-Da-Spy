using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform player; 
    
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

        transform.localRotation = Quaternion.Euler(xRotation,0.0f,0.0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
