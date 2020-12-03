using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    private bool Toggle = false;
    private Light myLight;
    //private float tempRandom { get => Random.Range(2f, 5f); }

    void Start()
    {
        Toggle = false;
        myLight = GetComponent<Light>();
        SetLight();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Toggle = !Toggle;
            SetLight();
        }
    }

    private void SetLight()
    {
        if (Toggle)
        {
            myLight.intensity = 2f;
            StartCoroutine(LightningStrike());
        }
        else
        {
            myLight.intensity = 0f;
        }
    }
    private IEnumerator LightningStrike()
    {
        myLight.intensity = 2f;
        yield return new WaitForEndOfFrame();
        myLight.intensity = 0f;
        if (Random.Range(0f,1f) > 0.5f)
        {
            yield return new WaitForSeconds(Random.Range(0.01f, 0.15f));
            myLight.intensity = 2f;
            yield return new WaitForEndOfFrame();
            myLight.intensity = 0f;
        }
    }

}
