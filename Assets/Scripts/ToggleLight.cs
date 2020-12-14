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
        }
        else
        {
            myLight.intensity = 0f;
        }
    }
    
}
