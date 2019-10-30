using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class Puertas : MonoBehaviour, IInteractable
{
    public bool Locked;
    public GameObject key;
    public AudioClip OpenSnd;
    public AudioClip CloseSnd;
    public AudioClip[] LockedSnds;
    Animation anim;
    BoxCollider cll;
    AudioSource asrc;
    bool Open = false;
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        asrc = gameObject.GetComponent<AudioSource>();
        cll = gameObject.GetComponent<BoxCollider>();
    }
    public void Use()
    {
        if (Locked)
        {
            if (!key)
            {
                Locked = false;
                Use();
            }
        }
        else
        {
            anim.Play(Open ? "Armature|DoorClose" : "Armature|DoorOpen");
            Open = !Open;
            cll.isTrigger = Open;
        }
        DoorSound();
    }

    void DoorSound()
    {
        AudioClip selected;
        if (Locked)
        {
            selected = LockedSnds[Random.Range(0, LockedSnds.Length)];
        }
        else
        {
            selected = Open ? OpenSnd : CloseSnd;
        }
        asrc.clip = selected;
        asrc.Play();
    }
}
