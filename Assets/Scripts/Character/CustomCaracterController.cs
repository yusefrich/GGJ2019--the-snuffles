using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCaracterController : MonoBehaviour
{

    [Header("ground check reference")]
    public Transform checkDeChao;// o grandioso check de chao
    public float checkRadiando;//check de chao
    public LayerMask layerChao;//mascara de layer para funfar o check de chao
    private bool touchGround; // Tocando o chão.

    public CharacterStatus characterStatus;//struct

    private Rigidbody2D rb;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        if(GetComponent<Animator>() != null)
        {
            anim = GetComponent<Animator>();
        }
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 moveVelocity)
    {
        if (GetComponent<Animator>() != null)
        {
            if (moveVelocity.x != 0 || moveVelocity.y != 0)
            {
                anim.SetFloat("Xspeed", moveVelocity.x);
                anim.SetFloat("Yspeed", moveVelocity.y);
                anim.SetBool("Moving", true);
            }
            else
            {
                anim.SetBool("Moving", false);
            }
        }


        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        //rb.velocity = new Vector2(moveVelocity.x * Time.fixedDeltaTime, moveVelocity.y * Time.fixedDeltaTime);

        //checking player ground
        characterStatus.onGround = Physics2D.OverlapCircle(checkDeChao.position, checkRadiando, layerChao);
        if (characterStatus.onGround)
        {
            //print("NoChaoooooo");
        }else
        {
            //print("NoLimboooooo");
        }


    }

    public struct CharacterStatus
    {
        public bool onGround;
    }
}
