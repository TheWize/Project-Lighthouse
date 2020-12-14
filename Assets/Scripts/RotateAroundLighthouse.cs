using UnityEngine;

public class RotateAroundLighthouse : MonoBehaviour
{
    Light Light;
    public Transform Axis;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Light = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        Axis.Rotate(Vector3.up * Time.deltaTime * speed);
        Light.transform.LookAt(this.transform);
    }
}
