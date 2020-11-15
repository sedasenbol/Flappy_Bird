using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Pipe : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        Destroy();
    }
    private void Destroy()
    {
        if (player.transform.position.x > transform.position.x + 35f)
        {
            Destroy(this.gameObject);
        }
    }
}
