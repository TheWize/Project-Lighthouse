using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundLighthouse : MonoBehaviour
{
    Light light;
    public Transform Axis;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        Axis.Rotate(Vector3.up * Time.deltaTime * speed);
        light.transform.LookAt(this.transform);
    }
}
