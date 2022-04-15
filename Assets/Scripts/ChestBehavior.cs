using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehavior : MonoBehaviour
{
    public Transform player;
    public GameObject image;
    public GameObject canvas;
    public GameObject levelManager;
    public GameObject enemiesRemain;
    private bool canvasOn;
    // Start is called before the first frame update
    void Start()
    {

        canvasOn = false;
        image.SetActive(false);
        enemiesRemain.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance < 4)
        {
            image.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                {
                    Debug.Log("cleared");
                    canvasOn = !canvasOn;
                } else
                {
                    enemiesRemain.SetActive(true);
                }
                
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                canvasOn = false;
            }
            if (canvasOn)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                canvas.SetActive(true);
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                canvas.SetActive(false);
            }
        }
        else if (distance > 4 && distance < 5)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            canvasOn = false;
            canvas.SetActive(false);
            image.SetActive(false);
            enemiesRemain.SetActive(false);
        }
    }

    // signifies that one of the shop buttons is pressed.
    public void ButtonPressed(int buttonNumber, int shopNumber)
    {
        levelManager.GetComponent<Upgrades>().useUpgrade(buttonNumber, shopNumber);
    }
}
