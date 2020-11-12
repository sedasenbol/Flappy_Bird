using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Tree : MonoBehaviour
{
    private GameObject player;
    private readonly float speed = 135f;
    private float startingYPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        startingYPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
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
