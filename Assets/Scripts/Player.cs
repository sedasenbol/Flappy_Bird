using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager gameManager;
    private bool isAlive = true;
    private Rigidbody2D rb;
    private readonly float moveForwardSpeed = 0.03f;
    private readonly float force = 250f;
    private Quaternion downRotation;
    private Quaternion forwardRotation;
    private readonly float rotationSmoothness=1.5f;
    private bool isFlying = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlying == false)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, rotationSmoothness * Time.deltaTime);
        }
        if (isAlive)
        {
            downRotation = Quaternion.Euler(0, 0, -120);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isFlying = true;
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
        StartCoroutine(ChangeRotationForward());
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector2.up * force);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        isAlive = false;
        GameOver();
    }
    private void GameOver()
    {
        isAlive = false;
        gameManager.GameOver();
    }
    IEnumerator ChangeRotationForward()
    {
        for (int i=0;  i < 40; i++)
        {
            forwardRotation = Quaternion.Euler(0, 0, 30);
            transform.rotation = forwardRotation;
            yield return new WaitForEndOfFrame();
            if (i == 39)
            {
                isFlying = false;
            }
        }
    }
    
}
