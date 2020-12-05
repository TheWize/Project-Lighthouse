using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    private Animator animator;

    [Header("Interactivity")]
    [SerializeField] private bool autoOpen;
    [SerializeField] private bool autoClose;
    [SerializeField] private bool locked;
    [SerializeField] private bool LockOnClose;
    [SerializeField] private KeyTrigger Key;

    [Space]

    [Header("Feedback")]
    [SerializeField] private AudioSource LockedSound;
    [SerializeField] private AudioSource OpenSound;
    [SerializeField] private AudioSource CloseSound;
    [SerializeField] private AudioSource UnlockedSound;

    [Header("ExtraTriggers")]
    public DoorTrigger trigger1;
    public DoorTrigger trigger2;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (autoOpen || Key == null)
        {
            locked = false;
        }
    }
    private void Update()
    {
        if (trigger1 != null && trigger1.gameObject.activeInHierarchy)
        {
            if (trigger1.triggered)
            {
                Trigger1();
                trigger1.gameObject.SetActive(false);
            }
        }
        if (trigger2 != null && trigger2.gameObject.activeInHierarchy)
        {
            if (trigger2.triggered)
            {
                Trigger2();
                trigger2.gameObject.SetActive(false);
            }
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && autoOpen)
        {
            locked = false;
            OpenDoor();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (autoClose)
            {
                CloseDoor();
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetMouseButtonDown(0))
        {
            OpenDoor();
        }
    }
    public void Trigger1()
    {
        animator.SetTrigger("Trigger1");

    }
    public void Trigger2()
    {
        animator.SetTrigger("Trigger2");
    }
}
