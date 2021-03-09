using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackFish : MonoBehaviour
{
    public List<GameObject> locs;
    private Queue<GameObject> qlocs;
    public float duration = 5f;
    private bool flip;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        flip = true;
        qlocs = new Queue<GameObject>();
        foreach (GameObject go in locs)
        {
            qlocs.Enqueue(go);
        }
        NextUp();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void NextUp()
    {
        GameObject pong = qlocs.Dequeue();
        StartCoroutine(LerpPosition(pong.transform.position));
        qlocs.Enqueue(pong);
    }

    IEnumerator LerpPosition(Vector3 targetPosition)
    {
        float time = 0;
        Vector3 startposition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startposition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        flip = !flip;
        Flip(flip);
        NextUp();
    }

    void Flip(bool f)
    {
        if (f){
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }


}