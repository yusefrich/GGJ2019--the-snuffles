using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, _Interactable
{
    public GameObject meEnemy;

    public GameObject itemDrop;

    public int GetInteractType()
    {
        return 1;
    }

    public void interactWith()
    {
        if(itemDrop != null)
        {
            print("interacted with item");
            Instantiate(itemDrop, meEnemy.transform.position, meEnemy.transform.rotation);
        }

        GameObject.FindWithTag("CustomAudioManager").GetComponent<CustomAudioManager>().dealDmg.Play();

        Destroy(meEnemy);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
