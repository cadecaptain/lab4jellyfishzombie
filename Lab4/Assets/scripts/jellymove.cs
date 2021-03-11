using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jellymove : MonoBehaviour
{
	//public GameObject target;
	public float runSpeed;
	public float rotateSpeed;

	private float horizontal;
	private float vertical;
	private Rigidbody2D body;

	public GameObject projectile;


	// Use this for initialization
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
			clone.transform.Rotate(new Vector3(0, 0, 90));
			clone.GetComponent<Rigidbody2D>().velocity = clone.transform.right * 20;
		}
	}

	private void FixedUpdate()
	{
		//body.AddForce(transform.up * vertical * runSpeed);
		body.velocity = transform.up * vertical * runSpeed;
		transform.Rotate(Vector3.back * horizontal * rotateSpeed);
	}

}
