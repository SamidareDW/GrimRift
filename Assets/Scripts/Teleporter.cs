using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform transformToTeleportOn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.position = transformToTeleportOn.position;
            SoundManager.current.PlaySound(SoundManager.Sound.Warp);
        }
    }
}