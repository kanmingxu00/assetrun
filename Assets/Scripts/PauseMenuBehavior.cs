using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenuBehavior : MonoBehaviour
{
    public GameObject menu;
    public GameObject reticle;
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public Slider sensitivitySlider;
    public static bool isGamePaused;

    void Start()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            float volume = PlayerPrefs.GetFloat("volume");
            Debug.Log("HasV Key");
            SetVolume(volume);
            volumeSlider.value = volume;
        }

        if (PlayerPrefs.HasKey("sensitivity"))
        {
            float sensitivity = PlayerPrefs.GetFloat("sensitivity");
            Debug.Log("HasS Key");
            SetSensitivity(sensitivity);
            sensitivitySlider.value = sensitivity;
        }
    }

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
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void SetSensitivity(float sensitivity)
    {
        
        MouseLook.sensitivity = sensitivity;
        PlayerPrefs.SetFloat("sensitivity", sensitivity);
    }
}
