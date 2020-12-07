using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class DoorTrigger : Door
{
    [SerializeField] private int TriggerNum;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ExtraTrigger(TriggerNum);
        }
    }
    public override void ExtraTrigger(int num)
    {
        base.ExtraTrigger(num);
    }
}
