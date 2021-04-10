using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickable : MonoBehaviour
{
    public bool selected = false;
    public bool holeded = false;
    // Start is called before the first frame update
    private void Update()
    {
        Material mymat = GetComponent<Renderer>().material;
        if (selected == true || holeded == true)
        {
            mymat.SetColor("_EmissionColor", Color.red);
        }
        else
        {
            mymat.SetColor("_EmissionColor", Color.black);
        }

    }
}
