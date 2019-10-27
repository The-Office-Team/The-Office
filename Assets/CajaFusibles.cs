using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaFusibles : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public void Use()
    {
        GameManager.FusiblesInsertados = GameManager.FusiblesRecogidos;
    }
}
