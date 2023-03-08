using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneAnimation : MonoBehaviour
{
    public GameObject player1;

    void Start() {
        player1 = GameObject.Find("Text (TMP)");
        player1.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            player1.SetActive(true);
            GetComponent<Animator>().Play("player1_fade");
            //player1.SetActive(false);
        }        
    }
}
