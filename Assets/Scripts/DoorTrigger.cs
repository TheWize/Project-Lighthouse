using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private int TriggerNum;
    Door door;

    private void Start()
    {
        door = GetComponentInParent<Door>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ExtraTrigger(TriggerNum);
        }
    }
    public void ExtraTrigger(int num)
    {
        if (num == 1)
        {
            StartCoroutine(OpenThenClose());
        }
        if (num == 2)
        {
            door.LockOnClose = true;
            door.CloseDoor();
        }
        else
        {
            Debug.LogError("Trigger Not Found!");
        }
    }
    private IEnumerator OpenThenClose()
    {
        door.OpenDoor();
        yield return new WaitForSeconds(2f);
        door.CloseDoor();
        gameObject.SetActive(false);
    }
}
