using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    private bool canTrigger;
    private bool mouseDown { get => Input.GetMouseButtonDown(0); }
    // Start is called before the first frame update
    void Start()
    {
        canTrigger = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

        }
    }
}
