using UnityEngine;

public class LighthouseInnerLightsHandler : MonoBehaviour
{
    public Animator anim;
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("PlayAnim", 1f);
        }
    }
    private void PlayAnim()
    {
        anim.SetTrigger("Trigger");
    }
}
