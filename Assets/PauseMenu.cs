using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public string nombre;
    public static bool GamePaused = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Start()
    {
        GamePaused = false;
        Resume();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PlayerMngr.instance.player.GetComponents<AudioSource>()[1].UnPause();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause()
    {
        PlayerMngr.instance.player.GetComponents<AudioSource>()[1].Pause();
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Exit(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
}
