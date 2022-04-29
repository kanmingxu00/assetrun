using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseMenuBehavior : MonoBehaviour
{
    public GameObject menu;
    public GameObject reticle;
    public AudioMixer audioMixer;
    public static bool isGamePaused;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (menu.activeInHierarchy == false)
        {
            reticle.SetActive(false);
            menu.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            isGamePaused = true;
        }
        else
        {
            reticle.SetActive(true);
            menu.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isGamePaused = false;
        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetSensitivity(float sensitivity)
    {
        MouseLook.sensitivity = sensitivity;
    }
}
