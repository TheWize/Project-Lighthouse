using UnityEngine;

public class DotheThing : MonoBehaviour
{
    public Transform trans;

    void Update()
    {
        transform.LookAt(trans);
    }
}
