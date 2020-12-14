using UnityEngine;

public class CameraFloat : MonoBehaviour
{
    // Start is called before the first frame update
    private float startHeight;
    [SerializeField] private float magnitude;
    [SerializeField] private float speed;
    void Start()
    {
        startHeight = transform.localPosition.y;
    }
    private void Update()
    {
        float _heightDelta = startHeight + Mathf.Sin(Time.time * speed) * magnitude;
        transform.localPosition = Vector3.up * (_heightDelta);
    }
}
