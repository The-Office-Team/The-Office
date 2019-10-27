using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private GameObject player;
    public string Scene;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerMngr.instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 2)
        {
            _GameOver(Scene);
        }
    }

    void _GameOver(string Scene)
    { 
        SceneManager.LoadScene(Scene);
    }

    
}
