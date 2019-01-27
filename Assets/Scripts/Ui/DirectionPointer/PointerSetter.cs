using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerSetter : MonoBehaviour
{
    [Header("pointing to house")]
    public GameObject housePointerDirection;
    public GameObject houseIconPlace;
    public GameObject houseIcon;
    [Header("pointing to close food")]
    public GameObject meatPointerDirection;
    public GameObject meatIconPlace;
    public GameObject meatIcon;
    [Header("pointing to close water")]
    public GameObject waterPointerDirection;
    public GameObject waterIconPlace;
    public GameObject waterIcon;
    [Header("pointing to close fire")]
    public GameObject firePointerDirection;
    public GameObject fireIconPlace;
    public GameObject fireIcon;


    // Update is called once per frame
    void Update()
    {
        PointingHouse();

        PointingWater();

        PointingFire();

        PointingMeat();
    }
    void PointingHouse()
    {
        GameObject house = GameObject.FindWithTag("HouseCenterPoint");

        var dir = house.transform.position - housePointerDirection.transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        housePointerDirection.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // setting house icon
        houseIcon.transform.position = houseIconPlace.transform.position;
    }

    void PointingWater()
    {
        
        GameObject[] waterItem = GameObject.FindGameObjectsWithTag("Water");

        if (waterItem.Length == 0)
        {
            waterPointerDirection.SetActive(false);
            waterIconPlace.SetActive(false);
            waterIcon.SetActive(false);

            return;
        }

        int closestObjectId = 0;
        float closestDistance = 99999f;
        //getting the closest
        for (int i = 0; i < waterItem.Length; i++)
        {
            if(Vector2.Distance(waterItem[i].transform.position, transform.position) < closestDistance)
            {
                closestObjectId = i;
                closestDistance = Vector2.Distance(waterItem[i].transform.position, transform.position);
            }
        }

        //seeing if the closest is close enougth
        if(Vector2.Distance(waterItem[closestObjectId].transform.position, transform.position) <10)
        {
            waterPointerDirection.SetActive(true);
            waterIconPlace.SetActive(true);
            waterIcon.SetActive(true);
        }else
        {
            waterPointerDirection.SetActive(false);
            waterIconPlace.SetActive(false);
            waterIcon.SetActive(false);
        }
        //moving the pointer

        var dir = waterItem[closestObjectId].transform.position - waterPointerDirection.transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        waterPointerDirection.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // setting water icon
        waterIcon.transform.position = waterIconPlace.transform.position;

    }
    void PointingFire()
    {
        
        GameObject[] fireItem = GameObject.FindGameObjectsWithTag("Fire");

        if (fireItem.Length == 0)
        {
            firePointerDirection.SetActive(false);
            fireIconPlace.SetActive(false);
            fireIcon.SetActive(false);

            return;
        }

        int closestObjectId = 0;
        float closestDistance = 99999f;
        //getting the closest
        for (int i = 0; i < fireItem.Length; i++)
        {
            if(Vector2.Distance(fireItem[i].transform.position, transform.position) < closestDistance)
            {
                closestObjectId = i;
                closestDistance = Vector2.Distance(fireItem[i].transform.position, transform.position);
            }
        }

        //seeing if the closest is close enougth
        if(Vector2.Distance(fireItem[closestObjectId].transform.position, transform.position) < 10)
        {
            firePointerDirection.SetActive(true);
            fireIconPlace.SetActive(true);
            fireIcon.SetActive(true);
        }else
        {
            firePointerDirection.SetActive(false);
            fireIconPlace.SetActive(false);
            fireIcon.SetActive(false);
        }
        //moving the pointer

        var dir = fireItem[closestObjectId].transform.position - firePointerDirection.transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        firePointerDirection.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // setting water icon
        fireIcon.transform.position = fireIconPlace.transform.position;

    }
    void PointingMeat()
    {
        
        GameObject[] meatItem = GameObject.FindGameObjectsWithTag("Meat");

        if (meatItem.Length == 0)
        {
            meatPointerDirection.SetActive(false);
            meatIconPlace.SetActive(false);
            meatIcon.SetActive(false);

            return;
        }

        int closestObjectId = 0;
        float closestDistance = 99999f;
        //getting the closest
        for (int i = 0; i < meatItem.Length; i++)
        {
            if(Vector2.Distance(meatItem[i].transform.position, transform.position) < closestDistance)
            {
                closestObjectId = i;
                closestDistance = Vector2.Distance(meatItem[i].transform.position, transform.position);
            }
        }

        //seeing if the closest is close enougth
        if(Vector2.Distance(meatItem[closestObjectId].transform.position, transform.position) < 10)
        {
            meatPointerDirection.SetActive(true);
            meatIconPlace.SetActive(true);
            meatIcon.SetActive(true);
        }else
        {
            meatPointerDirection.SetActive(false);
            meatIconPlace.SetActive(false);
            meatIcon.SetActive(false);
        }
        //moving the pointer

        var dir = meatItem[closestObjectId].transform.position - meatPointerDirection.transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        meatPointerDirection.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // setting water icon
        meatIcon.transform.position = meatIconPlace.transform.position;

    }
}
