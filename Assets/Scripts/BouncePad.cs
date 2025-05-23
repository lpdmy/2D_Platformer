﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerPad : MonoBehaviour
{
    private Animator anim;
    public float bounceForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.theRB.linearVelocity = new Vector2(PlayerController.instance.theRB.linearVelocity.x, bounceForce);
            anim.SetTrigger("Bounce");
        }
    }
}