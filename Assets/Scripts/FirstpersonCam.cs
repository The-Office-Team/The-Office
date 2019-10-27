using UnityEngine;
using System.Collections;

public class FirstpersonCam : MonoBehaviour
{
    public Texture2D crosshairImage;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private CursorLockMode wantedMode;

    public GameObject plyobj;

    void SetCursorState()
    {
        Cursor.lockState = wantedMode;
        Cursor.visible = (CursorLockMode.Locked != wantedMode);
    }

    void Start()
    {
        /*yaw = transform.eulerAngles.x;
        pitch = transform.eulerAngles.y;*/
        wantedMode = CursorLockMode.Locked;
        SetCursorState();
    }

    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        if (pitch > 90f)
        {
            pitch = 90f;
        }
        if (pitch < -90f)
        {
            pitch = -90f;
        }

        if (!PauseMenu.GamePaused)
        {
            plyobj.transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
            transform.eulerAngles = new Vector3(pitch, yaw, 0);
        }
        //Interacción
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit raycast;
            if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out raycast, 2.5f))
            {
                if (raycast.collider.gameObject.CompareTag("Interactable"))
                {
                    IInteractable interactable = (IInteractable)raycast.collider.gameObject.GetComponent(typeof(IInteractable));
                    interactable.Use();
                }
            }
        }
    }
    void OnGUI()
    {
        if (!PauseMenu.GamePaused)
        {
            float xMin = (Screen.width / 2) - (crosshairImage.width / 2);
            float yMin = (Screen.height / 2) - (crosshairImage.height / 2);
            GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width / 2, crosshairImage.height / 2), crosshairImage);
        }
    }
}