using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    Vector3 startPOS;
    Vector3 endPOS;

    public float lerpSpeed = 1.0f; 
    float lerpDir = 1.0f;
    float lerpTime = 0.0f;
    public Sprite left, right;
    // Start is called before the first frame update
    void Start()
    {
        startPOS = transform.Find("start").position;
        endPOS = transform.Find("end").position;
    }

    // Update is called once per frame
    void Update()
    {
        lerpTime += Time.deltaTime * lerpSpeed * lerpDir;
        if (lerpTime >= 1 && lerpDir > 0) {
            lerpDir = -1; 
            GetComponent<SpriteRenderer>().sprite = left;

        } 
        else if (lerpTime <= 0 && lerpDir < 0) {
            lerpDir = 1;
            GetComponent<SpriteRenderer>().sprite = right;

        }

        transform.position = Vector3.Lerp(startPOS, endPOS, lerpTime);
    }
}
