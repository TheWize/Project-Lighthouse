using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthouseInnerLightsHandler : MonoBehaviour
{
    private bool canActivate;

    private void Start()
    {
        canActivate = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!canActivate)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            GetComponentInParent<Animator>().SetTrigger("Trigger");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canActivate = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canActivate = false;
        }
    }
}
