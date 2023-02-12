using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField] Transform itemSlot;
    GameObject holdenItem;
    Camera playerCamera;
    [SerializeField] float playerRange = 5f;

    private void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        if (GetComponent<MyPlayerController>().blockActions == false)
        {
            if (Input.GetMouseButtonDown(0))
                CheckForItems();
            if (Input.GetMouseButtonDown(1))
                DropHoldenItem();
        }
    }

    void PickUp(GameObject item)    // Do poprawy
    {
        if (CheckIfSlotForItemIsFull())
            DropHoldenItem();
        // jeśli ma to usuń rigidbody przedmiotu
        Rigidbody itemRigidbody = item.GetComponent<Rigidbody>();
        if (itemRigidbody != null)
            Destroy(itemRigidbody);

        // rotate item
        SetProperRotationOf(item.transform);

        //  wyłącz collider przedmiotu
        if (item.GetComponent<Collider>().enabled)
            ChangeColliderEnable(item.GetComponent<Collider>());

        // uczyń item dzieckiem slotu a następnie ładnie przesuń leprem czy coś, zależy od IK rąk 
        item.transform.SetParent(itemSlot);
        item.transform.position = itemSlot.position;
        holdenItem = item;
        SoundManager.current.PlaySound(SoundManager.Sound.PickingUp);
    }

    void ChangeColliderEnable(Collider collider) => collider.enabled = !collider.enabled;

    bool CheckIfSlotForItemIsFull() { return itemSlot.childCount >= 1 ? true : false; }

    void DropHoldenItem()
    {
        if(CheckIfSlotForItemIsFull())
        {
            Rigidbody itemRigidbody;
            holdenItem.TryGetComponent<Rigidbody>(out itemRigidbody);
            if (itemRigidbody == null)
                itemRigidbody = holdenItem.AddComponent<Rigidbody>();
            holdenItem.transform.SetParent(null);

            //  włącz collider przedmiotu
            if (!holdenItem.GetComponent<Collider>().enabled)
                ChangeColliderEnable(holdenItem.GetComponent<Collider>());

            itemRigidbody.AddForce((transform.forward + transform.right) * 100);
            holdenItem = null;
            
        }
    }

    void SetProperRotationOf(Transform item)
    {
        if (item.CompareTag("Pickaxe"))
        {
            item.rotation = transform.rotation;
            item.Rotate(0, 0, 90);
        }
            
    }


    void CheckForItems()
    {
        RaycastHit raycastHitInfo;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out raycastHitInfo, playerRange))
        {
            var target = raycastHitInfo.collider.GetComponent<Interactable>();
            if (target != null)
                InteractWith(target);
            else
            {
                if (raycastHitInfo.collider.CompareTag("Pickaxe") || raycastHitInfo.collider.CompareTag("BlueShard") || raycastHitInfo.collider.CompareTag("YellowShard") || 
                    raycastHitInfo.collider.CompareTag("PurpleShard") || raycastHitInfo.collider.CompareTag("FirstShard") || raycastHitInfo.collider.CompareTag("SecondShard")
                    || raycastHitInfo.collider.CompareTag("ThirdShard") || raycastHitInfo.collider.CompareTag("FourthShard"))   //  do zmiany
                    PickUp(raycastHitInfo.collider.gameObject);
                
                else if (raycastHitInfo.collider.CompareTag("PaperCard"))
                {
                    raycastHitInfo.collider.GetComponent<PaperCard>().ShowCardContent();
                    //Debug.Log("Trafiono kartkę!");
                }
                else
                {
                    Debug.Log("Nothing to take");
                }
            }
        }
    }

    void InteractWith(Interactable target)
    {
        target.InteractionWith(holdenItem);

        if (itemSlot.childCount == 0)
            holdenItem = null;
    }
        
    


}
