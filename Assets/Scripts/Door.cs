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
    [SerializeField] private bool autoOpen;
    [SerializeField] private bool autoClose;
    [SerializeField] private bool locked;
    [SerializeField] private bool LockOnClose;
    public KeyTrigger Key;

    [Space]

    [Header("Feedback")]
    [SerializeField] private AudioSource LockedSound;
    [SerializeField] private AudioSource OpenSound;
    [SerializeField] private AudioSource CloseSound;
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
    private void OpenDoor()
    {
        if (locked)
        {
            if (Key.taken)
            {
                UnlockedSound.Play();
                locked = false;
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
    private void CloseDoor()
    {
        animator.SetBool("isOpen", false);
        if (LockOnClose)
        {
            locked = true;
        }
    }
    public virtual void ExtraTrigger(int num)
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
