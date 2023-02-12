using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject ingameMenu;
    public GameObject player;
    private GameObject playermove;
    bool Paused = false;
    
    void Start()
    {
        ingameMenu.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused == true)
            {
                player.GetComponent<MyPlayerController>().enabled = true;
                Time.timeScale = 1.0f;
                ingameMenu.SetActive(false);
               // Cursor.visible = false;
                //Screen.lockCursor = false;
                Paused = false;
            }
            else if (Paused == false)
            {
                player.GetComponent<MyPlayerController>().enabled = false;
                Time.timeScale = 0.0f;
                ingameMenu.SetActive(true);
                Cursor.visible = true;
                //Screen.lockCursor = true;
                Paused = true;
            }
        }
    }
}
