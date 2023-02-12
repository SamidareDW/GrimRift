using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : Interactable
{
    Transform itemSlot;

    [SerializeField] string activatingItemTag = "CrystalShard";

    bool _isActivated;
    public bool isActivated 
    {
        get { return _isActivated; }
        set 
        {
            if (_isActivated != value)
            {
                _isActivated = value;
                if (_isActivated)
                {
                    Debug.Log("Aktywowano Piedestał");
                }
                else
                {
                    Debug.Log("Dezktywowano Piedestał");
                }
                MyEventSystem.current.PedestalChangedState();
            }
        }
    }

    private void Start()
    {
        isActivated = false;
        itemSlot = transform.GetChild(0);
    }


    bool CheckIfSlotIsFull()
    {
        return itemSlot.transform.childCount >= 1 ? true : false;
    }

    void DropItemFromSlot()
    {
        if(CheckIfSlotIsFull())
        {
            itemSlot.GetChild(0).gameObject.GetComponent<Collider>().enabled = true;
            Rigidbody objRigidbody;
            if (!itemSlot.GetChild(0).TryGetComponent<Rigidbody>(out objRigidbody))
                objRigidbody = itemSlot.GetChild(0).gameObject.AddComponent<Rigidbody>();
            itemSlot.GetChild(0).transform.parent = null;
            objRigidbody.AddForce(Random.Range(30, 90), Random.Range(150, 300), Random.Range(30, 90));

        }
        isActivated = false;
    }

    bool CheckIfItemActivatesThePedestal(GameObject item)
    {
        return item.CompareTag(activatingItemTag);
    }

    void PutItemIntoSlot(GameObject item)
    {
        DropItemFromSlot();
        item.GetComponent<Collider>().enabled = false;
        item.transform.position = itemSlot.position;
        item.transform.SetParent( itemSlot.transform);

        SoundManager.current.PlaySound(SoundManager.Sound.PlaceOnPedestal);

        isActivated = CheckIfItemActivatesThePedestal(item);
    }

    protected override void InteractionWithCrystalShard(GameObject item) => PutItemIntoSlot(item);
    protected override void InteractionWithOther(GameObject item) => PutItemIntoSlot(item);
    protected override void InteractionWithPickaxe(GameObject item) => PutItemIntoSlot(item);

    protected override void InteractionWithNull() => DropItemFromSlot();

}
