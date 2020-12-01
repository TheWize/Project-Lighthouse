using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[ExecuteInEditMode]
public class RendererGroupSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    List<MeshRenderer> renderers = new List<MeshRenderer>();
    public bool Toggle;
    private bool tempToggle;
    private void Update()
    {
        if(tempToggle == Toggle) { return; }
        else
        {
            Refresh();
            tempToggle = Toggle;
        }

    }
    public void Refresh()
    {
        renderers.Clear();
        renderers.AddRange(GetComponentsInChildren<MeshRenderer>());
        foreach (MeshRenderer item in renderers)
        {
            item.enabled = Toggle;
        }

    }
}
