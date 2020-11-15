using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool playerIsDead = false;
    private Player player;
    private float forwardSpeed;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Player>();
        forwardSpeed = player.forwardSpeed;
    }
    private void FixedUpdate()
    {
        if(!playerIsDead)
        {
            rb.velocity = new Vector2(forwardSpeed, 0);
        }
    }
    public void GameOver()
    {
        playerIsDead = true;
        rb.velocity = Vector2.zero;
    }
}
