using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isAlive = true;
    private Rigidbody rb;
    private float moveForwardSpeed = 0.05f;
    private float force = 250f;
    private int score;
    private TreeScript treeScript;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        treeScript = GameObject.FindGameObjectWithTag("Obstacle").GetComponent<TreeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MoveVertical();
            }
            MoveForward();
        }
    }
    private void MoveForward()
    {
        transform.position = new Vector3(transform.position.x + moveForwardSpeed, transform.position.y, transform.position.z);
    }
    private void MoveVertical()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector2.up * force, ForceMode.Force);
    }
    private void OnTriggerEnter(Collider other)
    {
        isAlive = false;
        Physics.gravity = new Vector3(0, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        isAlive = false;
        Physics.gravity = new Vector3(0, 0, 0);
    }
    private void GameOver()
    {
        isAlive = false;
        treeScript.GameOver();
    }
}
