using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotheThing : MonoBehaviour
{
    public Transform trans;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(trans);
    }
}
