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
    private float rotationSmoothness=1.5f;
    private UIManager uIManager;
    private bool isFlying = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        treeScript = GameObject.FindGameObjectWithTag("Obstacle").GetComponent<TreeScript>();
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        Physics.gravity = new Vector3(0,20,0);

    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            downRotation = Quaternion.Euler(0, 0, -120);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isFlying = true;
                MoveVertical();
            }
            if(isFlying == false)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, rotationSmoothness * Time.deltaTime);
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
    IEnumerator ChangeRotationForward()
    {
        for (int i=0;  i < 45; i++)
        {
            forwardRotation = Quaternion.Euler(0, 0, 30);
            transform.rotation = forwardRotation;
            yield return new WaitForEndOfFrame();
            if (i == 44)
            {
                isFlying = false;
            }
        }
    }
    
}
