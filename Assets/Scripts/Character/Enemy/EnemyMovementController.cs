using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public float InitialSpeed;
    private float speed;
    private CustomCaracterController myController;
    private Vector2 moveVelocity;

    public GameObject[] movementRoutePoints;
    int currentCounterRoute = 1;

    public GameObject myRotationBody;

    public bool agrecive = true;

    // Start is called before the first frame update
    void Start()
    {
        speed = InitialSpeed;
        myController = GetComponent<CustomCaracterController>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 moveDirection = Vector2.zero;
        GameObject objToLookAt = null;
        switch (currentCounterRoute)
        {
            case 0:
                moveDirection = movementRoutePoints[0].transform.position - transform.position;
                if (Vector2.Distance(movementRoutePoints[0].transform.position, transform.position) <= .1)
                    currentCounterRoute++;
                objToLookAt = movementRoutePoints[0];
                break;
            case 1:
                moveDirection = movementRoutePoints[1].transform.position - transform.position;
                if (Vector2.Distance(movementRoutePoints[1].transform.position, transform.position) <= .1)
                    currentCounterRoute++;
                objToLookAt = movementRoutePoints[1];
                break;
            case 2:
                moveDirection = movementRoutePoints[2].transform.position - transform.position;
                if (Vector2.Distance(movementRoutePoints[2].transform.position, transform.position) <= .1)
                    currentCounterRoute++;
                objToLookAt = movementRoutePoints[2];

                break;
            case 3:
                moveDirection = movementRoutePoints[3].transform.position - transform.position;
                if (Vector2.Distance(movementRoutePoints[3].transform.position, transform.position) <= .1)
                    currentCounterRoute = 0;
                objToLookAt = movementRoutePoints[3];

                break;
            default:
                break;
        }
        if (agrecive)
        {
            //if dog is close the target is him
            GameObject pet = GameObject.FindWithTag("Pet");
            if (Vector2.Distance(transform.position, pet.transform.position) <= 3f)
            {
                moveDirection = pet.transform.position - transform.position;
                objToLookAt = pet;
                speed = InitialSpeed + 1;
            }
            else
            {
                speed = InitialSpeed;
            }

        }
        //rotate body to look at in 2d
        var dir = objToLookAt.transform.position - myRotationBody.transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        myRotationBody.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        moveVelocity = moveDirection.normalized * speed;


    }

    private void FixedUpdate()
    {
        myController.Move(moveVelocity);
    }

}
