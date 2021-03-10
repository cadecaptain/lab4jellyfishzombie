using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevelopMove : MonoBehaviour
{
    Rigidbody2D body;
    private float horizontal;
    private float vertical;
    public float runSpeed = 10f;
    private float moveLimiter = 0.7f;

    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown("space"))
        {
            //Quaternion.Euler(0,0,90 + transform.rotation.z)
            GameObject clone = Instantiate(projectile, transform.position, transform.rotation);
            clone.transform.Rotate(new Vector3(0,0,90));
            clone.GetComponent<Rigidbody2D>().velocity = clone.transform.right * 20;
        }

    }

    private void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
