using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class DoorEnterTrigger : MonoBehaviour
{
    public bool trigger;
    private void Start()
    {
        trigger = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            trigger = true;
            Debug.Log("Trigger" + this.name);
        }
    }
}
