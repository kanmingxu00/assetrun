using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public Transform player;
    public GameObject enemiesRemain;
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        image.SetActive(false);
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
                    FindObjectOfType<LevelManager>().LevelBeat();
                } else
                {
                    enemiesRemain.SetActive(true);
                }
            }
        }
        else if (distance > 4 && distance < 5)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            image.SetActive(false);
            enemiesRemain.SetActive(false);
        }
    }
}
