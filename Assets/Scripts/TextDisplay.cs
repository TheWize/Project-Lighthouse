using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    TextMeshProUGUI tmp;
    public static TextDisplay Instance;
    private Animator animator;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        tmp = GetComponent<TextMeshProUGUI>();
        tmp.color = new Color(1f, 1f, 1f, 0f);
        
    }
    public IEnumerator Play(string text, float time)
    {
        setText(text);
        ShowText();
        yield return new WaitForSeconds(time);
        HideText();
    }
    
    public void setText(string text)
    {
        tmp.text = text;
    }
    public void ShowText()
    {
        animator.SetTrigger("Show");
    }
    public void HideText()
    {
        animator.SetTrigger("Hide");
    }


}
