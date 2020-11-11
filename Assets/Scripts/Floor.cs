using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool playerIsDead = false;
    private Player player;
    private float forwardSpeed;
    //private readonly float moveForwardSpeed = 0.03f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Player>();
        forwardSpeed = player.forwardSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = new Vector3(player.transform.position.x + 1, transform.position.y,transform.position.z);
        if(playerIsDead == false)
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
