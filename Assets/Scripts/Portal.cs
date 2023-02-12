using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public List<Pedestal> pedestals = new List<Pedestal>();

    private float timeLeft = 3;
    private bool countdown = false;
    
    public GameObject canvas;
    //private void Awake() => MyEventSystem.current.whenPedestalChangedState += CheckIfPedestalsAreActive;


    private void Start()
    {
        MyEventSystem.current.whenPedestalChangedState += CheckIfPedestalsAreActive;
        GetComponent<Collider>().isTrigger = true;
        if (GetComponent<Collider>().enabled)
            GetComponent<Collider>().enabled = false;
        
        if (GetComponent<MeshRenderer>().enabled)
            GetComponent<MeshRenderer>().enabled = false;
            
        if (GetComponent<Light>().enabled)
            GetComponent<Light>().enabled = false;
    }


    private void Update()
    {

        if (countdown == true)
        {
            timeLeft -= Time.deltaTime;
            if ( timeLeft < 0 )
            {
                Application.Quit();
            }
        }
        //CheckIfPedestalsAreActive();
    }

    void CheckIfPedestalsAreActive()
    {
        int allPedestals = pedestals.Count;
        foreach(var p in pedestals)
        {
            if (p.isActivated)
                allPedestals -= 1;
            /*else
                break;*/
        }

        if (allPedestals == 0)
        {
            ActivatePortal();
        }
            
        
        else
            DeactivatePortal();


        Debug.Log($"Wywołano: CheckIfPedestalsAreActive() , Colider Status: {GetComponent<Collider>().enabled} , allPedestals = {allPedestals}");
    }

    void ActivateCollider() => GetComponent<Collider>().enabled = true;
    void DeactivateCollider() => GetComponent<Collider>().enabled = false;
    
    void ActivateMeshRenderer() => GetComponent<MeshRenderer>().enabled = true;
    
    void ActivateLight() => GetComponent<Light>().enabled = true;
    
    void DeactivateLight() => GetComponent<Light>().enabled = false;
    
    void DeactivateMeshRenderer() => GetComponent<MeshRenderer>().enabled = false;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Jej, Gra została ukończona!");
            canvas.SetActive(true);
            countdown = true;

        }
        else
            other.gameObject.SetActive(false);
    }

    private void OnDestroy()=> MyEventSystem.current.whenPedestalChangedState -= CheckIfPedestalsAreActive;

    private void ActivatePortal()
    {
        
        ActivateCollider();
        ActivateMeshRenderer();
        ActivateLight();
        SoundManager.current.PlaySound(SoundManager.Sound.ActivatingPortal);
        Debug.Log("Chuj");
    }
    
    private void DeactivatePortal()
    {
        DeactivateCollider();
        DeactivateMeshRenderer();
        DeactivateLight();
    }

}
