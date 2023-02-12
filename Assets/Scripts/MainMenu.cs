using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{

    //public GameObject ingameMenu;
    //public GameObject player;
    public Slider slider;
    public Text txtSlider;
    public float maxSettingValue;
    public float minSettingValue;

    void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined; 
    }
    public void PlayGame()
    {
        //yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(1);
    }
    
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
        
    }
    
    //public void ResumeGame()
    //{
      //  Time.timeScale = 1.0f;
        //ingameMenu.SetActive (false);
        //Cursor.visible = false;
        //Screen.lockCursor = true;
        //Cursor.lockState = CursorLockMode.Locked;
    //}
}
