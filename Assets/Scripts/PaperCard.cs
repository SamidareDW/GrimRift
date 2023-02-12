using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperCard : MonoBehaviour
{
    [SerializeField] GameObject Content;
    [SerializeField] GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Content.activeSelf)
            if (Input.GetMouseButton(1))
            {
                Content.SetActive(false);
                Player.GetComponent<MyPlayerController>().blockActions = false;
            }
    }


    public void ShowCardContent()
    {
        if (!Content.activeSelf)
        {
            Content.SetActive(true);
            Player.GetComponent<MyPlayerController>().blockActions = true;
        }
    }
    
}
