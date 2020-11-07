using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private GameObject player;
    private float speed = 0.017f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy();
        Move();

    }
    private void Destroy()
    {
        if (player.transform.position.x > transform.position.x + 35)
        {
            Destroy(this.gameObject);
        }
    }
    private void Move()
    {
        if (transform.position.x> player.transform.position.y - 20)
        {
            if (transform.position.y > 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
            }
            else if (transform.position.y < 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
            }
        }
    }
}
