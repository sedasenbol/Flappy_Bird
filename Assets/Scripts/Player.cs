using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isAlive = true;
    private Rigidbody rb;
    private float moveForwardSpeed = 0.03f;
    private float force = 250f;
    private int score;
    private TreeScript treeScript;
    private Quaternion downRotation;
    private Quaternion forwardRotation;
    private float rotationSmoothness=1f;
    private UIManager uIManager; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        treeScript = GameObject.FindGameObjectWithTag("Obstacle").GetComponent<TreeScript>();
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
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
            downRotation = Quaternion.Euler(0, 0, -90);
            transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, rotationSmoothness*Time.deltaTime);
            MoveForward();
        }
    }
    private void MoveForward()
    {
        transform.position = new Vector3(transform.position.x + moveForwardSpeed, transform.position.y, transform.position.z);
    }
    private void MoveVertical()
    {
        forwardRotation = Quaternion.Euler(0, 0, 35);
        rb.velocity = Vector3.zero;
        transform.rotation = forwardRotation;
        rb.AddForce(Vector2.up * force, ForceMode.Force);
    }
    private void OnTriggerEnter(Collider other)
    {
        isAlive = false;
        GameOver();
    }
    private void GameOver()
    {
        isAlive = false;
        // rb.velocity = new Vector3(0,0,0);
        treeScript.GameOver();
        uIManager.GameOver();
    }

}
