using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
//using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;

public class UISystem : MonoBehaviour
{
    
    
    Camera playerCamera;
    public GameObject OreMessage;
    public GameObject TakeMessage;
    public GameObject ReadMessage;
    public GameObject PlaceMessage;
    public GameObject ingameMenu;
    //[SerializeField] Volume volume;
    //Exposure grimExposure;
    float BrightnessExposure;
    private bool setPause = false;
    float Exposure;
    [Range(0f, 1f)] public float Brightness;

    void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
        //grimExposure = volume.GetComponent<Exposure>();
        
    }
    
    void Update()
    {
        CheckAndShowMessage();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GetComponent<MyPlayerController>().isDead==false)
            {
                if (!setPause)
                setPause = true;
                else if (setPause)
                setPause = false;
            
            }
        }
        
        //Debug.Log(grimExposure.fixedExposure.value);
        OpenMenu();
        //volume.GetComponent<Exposure>().fixedExposure.value = Brightness;
        //SetBrightness();
    }

    void SetBrightness()
    {

        //volume = GetComponent<Volume>();
        //Exposure expo = null;

        //volume.profile.TryGet(out expo);

        //expo.fixedExposure.value = 20;

    }
    
    
    void OpenMenu()
    {
        if (setPause)
        {
            ingameMenu.SetActive (true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            GetComponent<MyPlayerController>().blockActions = true;

        }
        else if (!setPause)
        {
            ingameMenu.SetActive (false);
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            GetComponent<MyPlayerController>().blockActions = false;
        }
    }
    
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
        
    }
    
    public void ResumeGame()
    {
        ingameMenu.SetActive (false);
        setPause = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GetComponent<MyPlayerController>().blockActions = false;
    }
    
    void CheckAndShowMessage()
    {
        RaycastHit hit;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out hit, 2))
        {

            if ((hit.collider.CompareTag("Ore")))
            {
                OreMessage.SetActive(true);
                TakeMessage.SetActive(false);
                ReadMessage.SetActive(false);
                PlaceMessage.SetActive(false);
            }

            
            else if ((hit.collider.CompareTag("Pickaxe")) || (hit.collider.CompareTag("BlueShard")) || (hit.collider.CompareTag("YellowShard")) || 
                     (hit.collider.CompareTag("PurpleShard")) || (hit.collider.CompareTag("FirstShard")) || (hit.collider.CompareTag("SecondShard"))
                     || (hit.collider.CompareTag("ThirdShard")) || (hit.collider.CompareTag("FourthShard")))
            {
                TakeMessage.SetActive(true);
                OreMessage.SetActive(false);
                ReadMessage.SetActive(false);
                PlaceMessage.SetActive(false);
            }
            
            else if ((hit.collider.CompareTag("PaperCard")))
            {
                ReadMessage.SetActive(true);
                TakeMessage.SetActive(false);
                OreMessage.SetActive(false);
                PlaceMessage.SetActive(false);
            }
            else if ((hit.collider.CompareTag("Pedestal")))
            {
                PlaceMessage.SetActive(true);
                TakeMessage.SetActive(false);
                OreMessage.SetActive(false);
                ReadMessage.SetActive(false);
            }
            
        }
        
        else
        {
            PlaceMessage.SetActive(false);
            ReadMessage.SetActive(false);
            TakeMessage.SetActive(false);
            OreMessage.SetActive(false); 
        }
    }
}
