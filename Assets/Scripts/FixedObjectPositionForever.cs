using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedObjectPositionForever : MonoBehaviour
{
    private Vector3 myInitialPosition;
    // Start is called before the first frame update
    void Start()
    {
        myInitialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = myInitialPosition;
    }
}
