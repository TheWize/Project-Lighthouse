using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    private Animator animator;
    private bool IsOpen { get => animator.GetBool("isOpen"); }
    private bool canClick;
    private bool mouseClicked;

    [Header("Interactivity")]
    public bool autoOpen;
    public bool autoClose;
    public bool LockIndefinetly;
    public bool locked;
    public KeyTrigger Key;

    [Space]

    [Header("Feedback")]
    [SerializeField] private AudioSource OpenSound;
    [SerializeField] private AudioSource CloseSound;
    [SerializeField] private AudioSource LockedSound;
    [SerializeField] private AudioSource UnlockedSound;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (autoOpen || Key == null)
        {
            locked = false;
        }
        canClick = false;
        mouseClicked = false;
    }
    private void Update()
    {
        if (!canClick)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            mouseClicked = true;
        }
    }
    public void OpenDoor()
    {
        if (LockIndefinetly)
        {
            return;
        }
        if (locked)
        {
            if (Key.taken)
            {
                UnlockedSound.Play();
                locked = false;
                animator.SetBool("isOpen", true);
            }
            else
            {
                LockedSound.Play();
            }
        }
        else
        {
            animator.SetBool("isOpen", true);
        }
    }
    public void CloseDoor()
    {
        animator.SetBool("isOpen", false);
        if (LockIndefinetly)
        {
            locked = true;
        }
    }
    public void ExtraTrigger(int num)
    {
        animator.SetTrigger("Trigger" + num);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canClick = true;
            if (autoOpen)
            {
                OpenDoor();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canClick = false;
            if (autoClose)
            {
                CloseDoor();
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (mouseClicked)
            {
                mouseClicked = false;
                if (!IsOpen)
                {
                    OpenDoor();
                }
                else
                {
                    CloseDoor();
                }
            }
        }
    }
}
