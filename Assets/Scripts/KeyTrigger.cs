using UnityEngine;
[RequireComponent(typeof(Collider))]
public class KeyTrigger : MonoBehaviour
{
    public bool taken;
    private void Start()
    {
        taken = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (taken)
        {
            return;
        }
        if (other.gameObject.CompareTag("Player") && Input.GetMouseButton(0))
        {
            OnTaken();
        }
    }
    private void OnTaken()
    {
        if (taken)
        {
            return;
        }
        taken = true;
        StartCoroutine(TextDisplay.Instance.Play("Key was picked", 1f));
        GetComponentInChildren<MeshRenderer>().enabled = false;
    }
}
