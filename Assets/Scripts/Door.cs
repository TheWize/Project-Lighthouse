using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    public DoorEnterTrigger enterTrigger;
    public DoorEnterTrigger exitTrigger;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (enterTrigger != null)
        {
            if (enterTrigger.trigger)
            {
                OpenDoor();
            }
        }
        if (exitTrigger != null)
        {
            if (exitTrigger.trigger)
            {
                CloseDoor();
            }
        }
    }
    private void OpenDoor()
    {
        enterTrigger.trigger = false;
        animator.SetTrigger("Open");
    }
    private void CloseDoor()
    {
        exitTrigger.trigger = false;
        animator.SetTrigger("Close");
    }
}
