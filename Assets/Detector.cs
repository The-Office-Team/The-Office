using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    void Update()
    {
        if (gameObject.GetComponent<MounstrueControlo>().seeingPlayer == false)
        {
            if (Input.GetKey(KeyCode.T))
            {
                print("fuck");
                //PlayerMngr.instance.monster.GetComponent<MounstrueControlo>().canSeePlayer = true;
                PlayerMngr.instance.monster.GetComponent<MounstrueControlo>().seenPlayer = true;
            }
            else
            {
                //PlayerMngr.instance.monster.GetComponent<MounstrueControlo>().canSeePlayer = false;
            }
        }
        else
        {
            //gameObject.GetComponent<MounstrueControlo>().canSeePlayer = true;
        }
    }
}
