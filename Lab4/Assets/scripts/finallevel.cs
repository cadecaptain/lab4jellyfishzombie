using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finallevel : MonoBehaviour
{
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
            GameManager.Instance.JellyNo();
            if (GameManager.Instance.GetScore() == 3) 
            {
                GameManager.Instance.NextScene("finallevel", whereTo);
            }


        }

    }


}