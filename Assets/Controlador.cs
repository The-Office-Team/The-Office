using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CambiarEscena(string nombre){
        print("Cambiando a la escena" + nombre);
        SceneManager.LoadScene(nombre);
    }

    public void Reintentar(string nombre)
    {
        print("Volviendo al juego");
        SceneManager.LoadScene(nombre);
    }
}
