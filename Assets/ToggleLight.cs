using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    private bool Toggle = false;
    private Light light;

    void Start()
    {
        light = GetComponent<Light>();
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
            light.intensity = 2f;
        }
        else
        {
            light.intensity = 0.2f;
        }
    }

}
