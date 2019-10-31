using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winscript : MonoBehaviour
{
    public GameObject cajule;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && GameManager.FusiblesInsertados == 2)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
