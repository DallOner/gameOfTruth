﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float distance = 32f;
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) 
        {
            if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f)
            {
                this.transform.Translate(new Vector3(Input.GetAxisRaw(horizontal) * distance, 0, 0));
            }

            if (Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
            {
                //targetPosition = new Vector3(this.transform.position.x, followTarget.transform.position.y, this.transform.position.z); //el target position seguira los pasos de x y y pero quedara alejada en z

                //this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, cameraSpeed * Time.deltaTime);

                //this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, (Input.GetAxisRaw(vertical) * distance), 0), (Input.GetAxisRaw(vertical) * distance) * Time.deltaTime);
                this.transform.Translate(new Vector2(0, Input.GetAxisRaw(vertical) * distance));

            }
        }

        

        animator.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        animator.SetFloat(vertical, Input.GetAxisRaw(vertical));
    }
}
