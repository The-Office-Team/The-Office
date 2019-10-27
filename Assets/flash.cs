using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flash : MonoBehaviour
{
    public float bateria;
    public Light luz;
    private bool fApretado = false;

    void Start()
    {
        luz = gameObject.GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && fApretado == false)
        {
            fApretado = true;
            if (luz.enabled == true)
            {
                luz.enabled = false;
            }
            else if (luz.enabled == false)
            { 
                luz.enabled = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            fApretado = false;
        }
    }
}