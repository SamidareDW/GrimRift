using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected abstract void InteractionWithPickaxe(GameObject item);
    protected abstract void InteractionWithCrystalShard(GameObject item);
    protected abstract void InteractionWithOther(GameObject item);
        

    protected abstract void InteractionWithNull();

    // protected virtual void InteractionEvent(GameObject item) => ...

    public virtual void InteractionWith(GameObject item)
    {
        if (item != null)
        {
            // narazie hamskie sprawdzanie nazwy -> później może sprawdzanie po enumie albo tagu -.-
            if (item.CompareTag("Pickaxe"))
                InteractionWithPickaxe(item);
            else if (item.CompareTag("BlueShard") || item.CompareTag("PurpleShard") || item.CompareTag("YellowShard"))
                InteractionWithCrystalShard(item);
            /*else if (item.CompareTag("PaperCard"))
            {
                item.GetComponent<PaperCard>().ShowCardContent();
                Debug.Log("Trafiono kartkę!");
            }*/
            else
                InteractionWithOther(item);
        }
        else
        { 
            InteractionWithNull();
        }
        // InteractionEvent(item);
    }
}
