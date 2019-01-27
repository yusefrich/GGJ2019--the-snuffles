using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetDono : MonoBehaviour
{
    public float speed;
    private CustomCaracterController myController;
    private Vector2 moveVelocity;

    public GameObject followPoint;
    public GameObject pet;

    bool cooldownSetter = true;
    float cooldown;
    public float cooldownSecods = 1f;

    public GameObject myRotationBody;

    public GameObject atackPop;
    public GameObject pickUpPop;

    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<CustomCaracterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //rotate body to look at in 2d
        var dir = followPoint.transform.position - myRotationBody.transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        myRotationBody.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Vector2 moveDirection = followPoint.transform.position - transform.position;
        float moveDistanceFromFollowPoint = Vector2.Distance(followPoint.transform.position, transform.position);

        if (pet.GetComponent<Player>().petStatus.followingPet)
        {
            cooldownSetter = true;  
            if (moveDistanceFromFollowPoint > 3)
            {
                moveVelocity = moveDirection.normalized * speed;
            }
            else
            {
                moveVelocity = Vector2.zero;
            }
        }
        else 
        {
            if (moveDistanceFromFollowPoint > .1f)
            {
                moveVelocity = moveDirection.normalized * speed;
            }
            else    
            {
                if (cooldownSetter)
                {
                    cooldown = Time.time + cooldownSecods;
                    cooldownSetter = false;
                }
                if (cooldown <= Time.time)
                    pet.GetComponent<Player>().ReachedFollowPoint();
                moveVelocity = Vector2.zero;
            }
        }

    }

    private void FixedUpdate()
    {
        myController.Move(moveVelocity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<_Interactable>() != null)
        {
            int interactType = collision.GetComponent<_Interactable>().GetInteractType();
            switch (interactType)
            {
                case 1:
                    atackPop.SetActive(true);
                    break;
                case 2:
                    pickUpPop.SetActive(true);
                    break;
                default:
                    break;
            }
            collision.GetComponent<_Interactable>().interactWith();
        }

    }

}
