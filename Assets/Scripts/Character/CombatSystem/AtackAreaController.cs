using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackAreaController : MonoBehaviour
{
    float cooldown;
    public float cooldownSecods = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<_Idamageable>() != null)
        {
            if (cooldown <= Time.time)
            {
                collision.GetComponent<_Idamageable>().DealDamage();
                cooldown = Time.time + cooldownSecods;
            }

        }
    }
}
