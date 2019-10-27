using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseFusible : MonoBehaviour, IInteractable
{
    public void Use()
    {
        print("Used a fusible");
        GameManager.FusiblesRecogidos++;
        Destroy(gameObject);
    }
}
