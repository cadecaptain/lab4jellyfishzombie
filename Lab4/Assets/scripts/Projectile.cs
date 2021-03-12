using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Projectile : MonoBehaviour
{

    private GameObject target;
    public float speed;
    public float rotationSpeed;
    private bool gotTarget = false;

    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
       /* if (!gotTarget)
        {
            Collider2D tarCol = Physics2D.OverlapCircle(transform.position, 20);
            if (tarCol.gameObject.CompareTag("Enemy"))
            {
                target = tarCol.gameObject;
                gotTarget = true;
            }
        }
       */
    }
    void FixedUpdate()
    {
       /* if (target != null && Physics2D.OverlapCircleAll(transform.position,20).Contains(target.GetComponent<Collider2D>())) {
            Vector2 desired = (target.transform.position - transform.position).normalized;

            float angle = (Mathf.Atan2(desired.y, desired.x) * Mathf.Rad2Deg) - 90;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation,
                q, Time.deltaTime * rotationSpeed);
            body.velocity = transform.right * 20;
        }
       */
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
           collider.gameObject.SetActive(false);
            GameManager.Instance.PlayZap();
            gameObject.SetActive(false);
        }
        else if (!collider.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
