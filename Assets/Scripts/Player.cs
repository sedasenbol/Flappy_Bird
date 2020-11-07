using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private float moveForwardSpeed = 0.05f;
    private float Force = 20f;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveVertical();
        }
        MoveForward();
    }
    private void MoveForward()
    {
        transform.position = new Vector3(transform.position.x+moveForwardSpeed,transform.position.y,transform.position.z);
    }
    private void MoveVertical()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector2.up * 250f, ForceMode.Force);
    }
    private void OnTriggerEnter(Collider other)
    {
        gameManager.GameOver();
    }
}
