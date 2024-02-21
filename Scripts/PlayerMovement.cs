using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 15f;
    [SerializeField] float jumpSpeed = 10f;

    //Vector 2 as we only have x and y axis in 2d space
    Vector2 moveInput;
    Rigidbody2D myrigidbody;
    BoxCollider2D myBoxCollider;

    bool top;
    void Start()
    {
       myrigidbody = GetComponent<Rigidbody2D>();
       myBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
        SwitchGravity();
    }

    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value){
        if(!myBoxCollider.IsTouchingLayers(LayerMask.GetMask("ground"))){
            return;
        }
        if(value.isPressed){
            myrigidbody.velocity+=new Vector2(0f,jumpSpeed);
        }
    }

    void Run(){
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed,myrigidbody.velocity.y);
        myrigidbody.velocity=playerVelocity;
    }

    void FlipSprite(){
        bool playerHasHorizontalSpeed = Mathf.Abs(myrigidbody.velocity.x)>Mathf.Epsilon;
        if(playerHasHorizontalSpeed){
            transform.localScale = new Vector2(0.1f*Mathf.Sign(myrigidbody.velocity.x),0.1f);
        }
    }

    void SwitchGravity(){
        if(Input.GetKey(KeyCode.R)){
            myrigidbody.gravityScale *= -1;

        }
    }

 /*   void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name=="trigger"){
            myrigidbody.gravityScale *= -1;
        }
    }*/
}
