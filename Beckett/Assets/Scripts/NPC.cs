
using System.Collections;
using UnityEngine;


    public class NPC : PlayerController
    {
    public float move = 5;
    public bool isMoving = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (isMoving == false) {
            transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0f, 0f));
        }
            transform.Translate(new Vector3(0f, moveSpeed * Time.deltaTime, 0f));

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));

    }

}

