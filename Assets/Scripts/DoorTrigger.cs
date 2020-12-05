using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class DoorTrigger : MonoBehaviour
{
    private Door doorRef;
    public bool triggered;
    private void Start()
    {
        triggered = false;
        doorRef = GetComponentInParent<Door>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggered = true;
        }
    }
}
