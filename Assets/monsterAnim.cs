using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class monsterAnim : MonoBehaviour
{
    // Start is called before the first frame update
    bool animPlaying = false;
    Animation anim;
    NavMeshAgent agent;
    private void Start()
    {
        agent = PlayerMngr.instance.monster.GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.velocity.magnitude > 0 && !animPlaying)
        {
            anim.Play();
            animPlaying = true;
        }
        else if (agent.velocity.magnitude <= 0)
        {
            animPlaying = false;
            anim.Stop();
        }
    }
}
