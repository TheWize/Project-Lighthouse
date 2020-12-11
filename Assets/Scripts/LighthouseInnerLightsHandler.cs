using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthouseInnerLightsHandler : MonoBehaviour
{
    private bool canActivate;
    public Animator anim;
    private void Start()
    {
        canActivate = false;
    }
    // Update is called once per frame
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("PlayAnim", 1f);
        }
    }
    private void PlayAnim()
    {
        anim.SetTrigger("Trigger");
    }
}
