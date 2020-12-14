using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class LightningStrikeHandler : MonoBehaviour
{
    private Light myParentsLight;
    public AudioSource myAudio;
    private void Start()
    {
        myParentsLight = GetComponentInParent<Light>();
    }
    private IEnumerator LightningStrike()
    {
        myAudio.gameObject.SetActive(true);
        myAudio.transform.parent = null;
        yield return new WaitForSeconds(.5f);
        myParentsLight.intensity = 5f;
        yield return new WaitForEndOfFrame();
        myParentsLight.intensity = 0f;
        yield return new WaitForSeconds(0.2f);
        myParentsLight.intensity = 5f;
        yield return new WaitForEndOfFrame();
        myParentsLight.intensity = 0f;
        transform.parent.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LightningStrike());
        }
    }
}
