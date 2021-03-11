using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jellysave3 : MonoBehaviour
{
    public int num = 3;
    public Vector3 whereTo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            GameManager.Instance.IncScore(1);
            GameManager.Instance.number(num);
            GameManager.Instance.Jelly3();
            GameManager.Instance.NextScene("centralhub", whereTo);


        }

    }


}
