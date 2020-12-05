using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class KeyTrigger : MonoBehaviour
{
    public bool taken;
    private void Start()
    {
        taken = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetMouseButtonDown(0))
        {
            OnTaken();
        }
    }
    private void OnTaken()
    {
        if (taken)
        {
            return;
        }
        taken = true;
        StartCoroutine(TextDisplay.Instance.Play("Key was picked", 1f));
        GetComponent<MeshRenderer>().enabled = false;
    }
}
