using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaFusibles : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public GameObject[] fusibles;
    public void Use()
    {
        GameManager.FusiblesInsertados = GameManager.FusiblesRecogidos;
        for (int i = 0; i < GameManager.FusiblesInsertados; i++)
        {
            fusibles[i].SetActive(true);
        }
    }
}
