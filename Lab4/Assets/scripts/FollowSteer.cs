using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSteer : MonoBehaviour
{

	public GameObject target;
	public float speed;
	public float rotationSpeed;

	private Rigidbody2D body;

	// Use this for initialization
	void Start()
	{
		body = GetComponent<Rigidbody2D>();
		target = GameObject.FindWithTag("Player");
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Vector2 desired = (target.transform.position - transform.position).normalized;
		body.AddForce(desired * speed - body.velocity);

		float angle = (Mathf.Atan2(desired.y, desired.x) * Mathf.Rad2Deg) - 90;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation,
			q, Time.deltaTime * rotationSpeed);

	}
}