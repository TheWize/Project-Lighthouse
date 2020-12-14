using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class TriggerHandler : MonoBehaviour
{
    [SerializeField] private int TriggerNum;
    [SerializeField] private GameObject flashlight;
    Door door;

    private void Start()
    {
        door = GetComponentInParent<Door>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (TriggerNum == 3)
            {
            }
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
            flashlight.SetActive(false);
            door.CloseDoor();
            door.LockIndefinetly = true;
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
        door.locked = true;
        gameObject.SetActive(false);
    }
}
