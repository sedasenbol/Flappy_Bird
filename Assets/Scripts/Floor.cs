using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool playerIsDead = false;
    //private readonly float moveForwardSpeed = 0.03f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = new Vector3(player.transform.position.x + 1, transform.position.y,transform.position.z);
        if(playerIsDead == false)
        {
            rb.velocity = new Vector2(3f, 0);
        }
    }
    public void GameOver()
    {
        playerIsDead = true;
        rb.velocity = Vector2.zero;
    }
}
