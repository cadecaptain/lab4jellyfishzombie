using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spider1 : MonoBehaviour
{
	private GameObject target;
	private float tarDist;
	public float speed;
	public float rotationSpeed;
	private bool tarActive = false;

	private Rigidbody2D body;

	// Use this for initialization
	void Start()
	{
		body = GetComponent<Rigidbody2D>();
		target = GameManager.Instance.GetPlayer();
		tarDist = 8;


	}
	// Update is called once per frame
	void Update()
	{

		if (Physics2D.OverlapCircleAll(transform.position, tarDist).Contains(target.GetComponent<Collider2D>()))
		{
			tarActive = true;
		}
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (tarActive)
		{

			Vector2 desired = (target.transform.position - transform.position).normalized;
			body.AddForce(desired * speed - body.velocity);

			float angle = (Mathf.Atan2(desired.y, desired.x) * Mathf.Rad2Deg) - 90;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation,
				q, Time.deltaTime * rotationSpeed);
		}

	}
	private void OnCollisionEnter2D(Collision2D collider)
	{
		if (collider.gameObject.CompareTag("Player"))
		{
			GameManager.Instance.PlayerHit();
		}
	}
}
