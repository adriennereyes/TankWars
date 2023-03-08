using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoAnimation : MonoBehaviour
{
    public GameObject player2;

    void Start() {
        player2 = GameObject.Find("Text (TMP)2");
        player2.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            player2.SetActive(true);
            GetComponent<Animator>().Play("player2_fade");
            player2.SetActive(false);
        }        
    }
}
