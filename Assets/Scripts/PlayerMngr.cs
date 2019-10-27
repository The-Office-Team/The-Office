using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMngr : MonoBehaviour
{
    // Este cosito nos permite asignar una variable para referirnos al jugador dónde nos pinte.
    #region Singleton

    public static PlayerMngr instance;

    void Awake()
    {
        instance = this;
    }

    #endregion
    public GameObject player; //PlayerMngr.instance.player en cualquier otro script ;)
    public GameObject monster; //PlayerMngr.instance.monster en cualquier otro script ;)
}
