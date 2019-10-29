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
    public GameObject Luces;
    bool Objetivo;
    // Start is called before the first frame update
    void Start()
    {
        FusiblesRecogidos = 0;
        FusiblesInsertados = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (FusiblesInsertados == 2 && Objetivo != true)
        {
            Luces.SetActive(true);
            Objetivo = true;
        }
    }

    public static void MenuPrincipal()
    {
        SceneManager.LoadScene("Menu");
    }
}
