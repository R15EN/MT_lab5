using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    Animator ch_Animator;
    Rigidbody Body;
    
    private bool R_Move, L_Move;
    private float Target_Position;
    public float Speed = 50f;
    public float Jump_Power = 4f;
    bool Can_Jump = false;

    void Start()
    {
        ch_Animator = GetComponent<Animator>();
        Body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        CharacterDisplacement();
    }

    void Update()
    {
        AnimatorController();
    }

    void AnimatorController()
    {
        if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
        {
            ch_Animator.SetBool("run_left", true);
            ch_Animator.SetBool("run_right", false);
        }

        else if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {
            ch_Animator.SetBool("run_right", true);
            ch_Animator.SetBool("run_left", false);
        }

        else
        {
            ch_Animator.SetBool("run_left", false);
            ch_Animator.SetBool("run_right", false);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ch_Animator.SetTrigger("run_jump");
        }
    }
    void CharacterDisplacement()
    {
        Can_Jump = IsGrounded();

        Body.AddForce(new Vector3(0, Physics.gravity.y * 5f, 0), ForceMode.Acceleration);

        if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
        {
            Body.AddForce(-transform.right * Speed * Time.fixedDeltaTime, ForceMode.Impulse);
            
        }

        else if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {
            Body.AddForce(transform.right * Speed * Time.fixedDeltaTime, ForceMode.Impulse);
        }
        
        if(Input.GetKey(KeyCode.Space) && Can_Jump==true)
        {
            Body.AddForce(new Vector3(0, Jump_Power, 0), ForceMode.Impulse);  
            Can_Jump = false;
            
        }
    }


    bool IsGrounded()
    {
        bool Grounded;
        Grounded = Physics.Raycast(new Vector3(transform.position.x,transform.position.y+1,transform.position.z), Vector3.down, 1.5f);
        return Grounded;
    }

    



}
