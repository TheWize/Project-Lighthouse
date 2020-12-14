using UnityEngine;
[RequireComponent(typeof(Collider))]
public class NamedArea : MonoBehaviour
{
    [SerializeField] private string setText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TextDisplay.Instance.setText(setText);
            TextDisplay.Instance.ShowText();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TextDisplay.Instance.HideText();
        }
    }
}
