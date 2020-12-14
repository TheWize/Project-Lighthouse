using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class LightningStrikeHandler : MonoBehaviour
{
    private Light myLight;
    private void Start()
    {
        myLight = GetComponentInParent<Light>();
    }
    private IEnumerator LightningStrike()
    {
        myLight.intensity = 2f;
        yield return new WaitForEndOfFrame();
        myLight.intensity = 0f;
        if (Random.Range(0f, 1f) > 0.5f)
        {
            yield return new WaitForSeconds(Random.Range(0.01f, 0.15f));
            myLight.intensity = 2f;
            yield return new WaitForEndOfFrame();
            myLight.intensity = 0f;
        }
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("yes");
            LightningStrike();
        }
    }
}
