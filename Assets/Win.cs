using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    private bool canTrigger;
    public GameObject[] objectsToActivate;
    private bool mouseDown { get => Input.GetMouseButtonDown(0); }
    // Start is called before the first frame update
    void Start()
    {
        canTrigger = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canTrigger)
        {
            WinFunc();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canTrigger = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canTrigger = true;
        }
    }
    private void WinFunc()
    {
        foreach (GameObject item in objectsToActivate)
        {
            item.SetActive(true);
        }
    }
}
