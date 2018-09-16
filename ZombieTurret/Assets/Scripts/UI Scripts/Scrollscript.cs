using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrollscript : MonoBehaviour {

    float scrollspeed = -1.0f;
    Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
        Time.timeScale = 2;
    }

    // Update is called once per frame
    void Update ()
    {
        float newPos = Mathf.Repeat(Time.time * scrollspeed, 45);
        transform.position = startPos + Vector2.right * newPos;
	}
}
