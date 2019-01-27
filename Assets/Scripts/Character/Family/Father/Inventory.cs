using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int water = 0;
    private int fire = 0;
    private int meat = 0;

    private void Start()
    {
        ResetAll();
    }

    public void AddWater(int quatity)
    {
        water += quatity;
        //setting the ui to show the items
        GameObject.FindWithTag("UiManager").GetComponent<CustomUiManager>().SetInventoryItems();

    }
    public void AddFire(int quatity)
    {
        fire += quatity;
        //setting the ui to show the items
        GameObject.FindWithTag("UiManager").GetComponent<CustomUiManager>().SetInventoryItems();

    }
    public void AddMeat(int quatity)
    {
        meat += quatity;
        //setting the ui to show the items
        GameObject.FindWithTag("UiManager").GetComponent<CustomUiManager>().SetInventoryItems();

    }

    public int GetWater()
    {
        return water;
    }
    public int GetFire()
    {
        return fire;
    }
    public int GetMeat()
    {
        return meat;
    }
    public void ResetAll()
    {
        water = 0;
        fire = 0;
        meat = 0;
        //setting the ui to show the items
        GameObject.FindWithTag("UiManager").GetComponent<CustomUiManager>().SetInventoryItems();

    }


}
