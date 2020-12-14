using UnityEngine;

public class ChangeFieldOfViewOnLeftclick : MonoBehaviour
{
    Camera cam;
    [SerializeField] private float cameraFar;
    [SerializeField] private float cameraNear;
    [SerializeField] private float strength;
    private float setFloat;
    void Start()
    {
        cam = GetComponent<Camera>();
        setFloat = cameraFar;
    }
    private void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            if (cam.fieldOfView <= cameraNear)
            {
                setFloat = cameraNear;
            }
            else
            {
                setFloat -= strength * Time.deltaTime;
            }
        }
        else 
        {
            if (cam.fieldOfView >= cameraFar)
            {
                setFloat = cameraFar;
            }
            else
            {
                setFloat += strength * Time.deltaTime;
            }
        }
        cam.fieldOfView = setFloat;
    }
}
