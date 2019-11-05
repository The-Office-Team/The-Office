using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spots;
    public GameObject lights;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        lights.SetActive(false);
        spots.SetActive(true);
    }
}
