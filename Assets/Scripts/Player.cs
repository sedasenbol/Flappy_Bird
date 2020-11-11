using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager gameManager;
    private bool isAlive = true;
    private Rigidbody2D rb;
    public readonly float forwardSpeed = 3f;
    private readonly float upwardsforce = 300f;
    private Quaternion downRotation;
    private Quaternion forwardRotation;
    private readonly float rotationSmoothness=1.5f;
    private bool isFlying = false;
    private readonly float gravityVelocity = 0.2f;
    private Floor floor;
    private Vector3 velocity;
    private float angularVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        floor = GameObject.Find("Floor").GetComponent<Floor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlying == false)
        {
            downRotation = Quaternion.Euler(0, 0, -90);
            transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, rotationSmoothness * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFlying = true;
            return;
        }
    }
    private void FixedUpdate()
    {
            if (!isAlive)
            { 
                return;
            }
            if (isFlying)
            {
                isFlying = false;
                MoveVertical();
            }
            MoveForward();
        
        //ApplyGravity();
    }
    private void MoveForward()
    {
        rb.velocity = new Vector2(forwardSpeed, rb.velocity.y - gravityVelocity);
        //transform.position = new Vector3(transform.position.x + moveForwardSpeed, transform.position.y, transform.position.z);
    }
    private void ApplyGravity()
    {
        rb.AddForce(Physics.gravity);
    }
    private void MoveVertical()
    {
        StartCoroutine(ChangeRotationForward());
        rb.velocity = new Vector2(rb.velocity.x,0f);
        rb.AddForce(Vector2.up * upwardsforce);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!isAlive)
        {
            return;
        }
        if(other.gameObject.layer == 9)
        {
            rb.velocity = new Vector2(0, -gravityVelocity * 20);
            GameOver();
            return;
        }
        if(other.gameObject.layer == 11)
        {
            rb.velocity = Vector2.zero;
            GameOver();
        }
    }
    private void GameOver()
    {
        isAlive = false;
        gameManager.GameOver();
        floor.GameOver();
    }
    IEnumerator ChangeRotationForward()
    {
        int TotalFrame = 90;
        for (int i=0;  i < TotalFrame; i++)
        {
            forwardRotation = Quaternion.Euler(0, 0, 30);
            transform.rotation = forwardRotation;
            yield return new WaitForEndOfFrame();
            if (i == TotalFrame - 1)
            {
                isFlying = false;
            }
        }
    }
    public void PauseGame()
    {
        velocity = rb.velocity;
        angularVelocity = rb.angularVelocity;
        rb.isKinematic = true;
    }
    public void ResumeGame()
    {
        rb.isKinematic = false;
        rb.velocity = velocity;
        rb.angularVelocity = angularVelocity;
    }
}
