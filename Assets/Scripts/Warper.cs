using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warper : MonoBehaviour
{
    [SerializeField] private float WarpHeight = 50;
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x,
            other.gameObject.transform.position.y + WarpHeight, other.gameObject.transform.position.z);
    }
}
