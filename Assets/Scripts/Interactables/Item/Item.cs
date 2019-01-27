using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, _Interactable
{
    public ItemType itemType;
    public int quantity = 1;

    public Sprite fire;
    public Sprite fireOutLine;
    public Sprite water;
    public Sprite waterOutLine;
    public Sprite meat;
    public Sprite meatOutLine;

    public SpriteRenderer graph;
    public SpriteRenderer outLine;



    public enum ItemType
    {
        fire, water, meat
    }

    public void interactWith()
    {
        //interacted with item
        print("interacted with item");
        //add item to inventory
        switch (itemType)
        {
            case ItemType.fire:
                GameObject.FindWithTag("PetDono").GetComponent<Inventory>().AddFire(quantity);

                break;
            case ItemType.water:
                GameObject.FindWithTag("PetDono").GetComponent<Inventory>().AddWater(quantity);

                break;
            case ItemType.meat:
                GameObject.FindWithTag("PetDono").GetComponent<Inventory>().AddMeat(quantity);

                break;
            default:
                break;
        }
        GameObject.FindWithTag("CustomAudioManager").GetComponent<CustomAudioManager>().pickUpItem.Play();
        //destroy me
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        switch (itemType)
        {
            case ItemType.fire:
                graph.sprite = fire;
                outLine.sprite = fireOutLine;
                break;
            case ItemType.water:
                graph.sprite = water;
                outLine.sprite = waterOutLine;
                break;
            case ItemType.meat:
                graph.sprite = meat;
                outLine.sprite = meatOutLine;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetInteractType()
    {
        return 2;
    }
}
