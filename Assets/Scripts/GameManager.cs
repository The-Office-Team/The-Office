using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*#region Singleton
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion*/
    public static int FusiblesRecogidos = 0;
    public static int FusiblesInsertados = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FusiblesInsertados == 2)
        {

        }
    }

    public static void MenuPrincipal()
    {
        SceneManager.LoadScene("Menu");
    }
}
