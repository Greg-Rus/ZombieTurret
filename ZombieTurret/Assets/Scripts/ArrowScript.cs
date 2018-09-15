﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    Rigidbody2D rb;
    public int Damage = 1;
    float killVelocity = 10;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var arrowImg = GetComponentInChildren<SpriteRenderer>();
        if (arrowImg.isVisible) return;
        Destroy(gameObject,1);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}