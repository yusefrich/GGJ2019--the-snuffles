using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, _Idamageable
{
    public float speed;

    private Vector2 moveVelocity;

    private CustomCaracterController myController;

    public GameObject followPoint;
    private Vector3 followPointClickPosition;

    public PetStatus petStatus;
    
    private CustomUiManager uiManager; //UiManager tag


    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.FindWithTag("UiManager").GetComponent<CustomUiManager>();
        petStatus.followingPet = true;
        myController = GetComponent<CustomCaracterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        //check for click
        if (Input.GetMouseButtonDown(0))
        {
            followPointClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            petStatus.followingPet = false;
        }

        // mooving the follow point
        if (petStatus.followingPet)
        {
            followPoint.transform.localPosition = new Vector3(0f, 0f, 0.5f);
        }
        else
        {
            followPoint.transform.position = new Vector3(followPointClickPosition.x, followPointClickPosition.y, followPoint.transform.position.z);

        }
    }

    public void ReachedFollowPoint()
    {
        petStatus.followingPet = true;
    }

    private void FixedUpdate()
    {
        myController.Move(moveVelocity);
    }

    public void Death()
    {
        uiManager.ShowDeathCanvas();
    }

    public void DealDamage()
    {
        Death();
        print("To Sofrenu danuuuu malukuuuuuu");
    }

    public struct PetStatus{
        public bool followingPet;
    }
}
