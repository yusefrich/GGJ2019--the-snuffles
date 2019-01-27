using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CustomUiManager : MonoBehaviour
{

    public GameObject deathCanvas;

    public GameObject[] waterItems;
    public GameObject[] fireItems;
    public GameObject[] meatItems;

    public void ShowDeathCanvas()
    {
        deathCanvas.SetActive(true);
    }

    public void SetInventoryItems()
    {
        //reseting current items
        foreach (var item in waterItems)
        {
            item.SetActive(false);
        }
        foreach (var item in fireItems)
        {
            item.SetActive(false);
        }
        foreach (var item in meatItems)
        {
            item.SetActive(false);
        }
        //setting water items
        for (int i = 0; i < GameObject.FindWithTag("PetDono").GetComponent<Inventory>().GetWater(); i++)
        {
            if(i < waterItems.Length)
            {
                waterItems[i].SetActive(true);
            }

        }
        for (int i = 0; i < GameObject.FindWithTag("PetDono").GetComponent<Inventory>().GetFire(); i++)
        {
            if(i < fireItems.Length)
            {
                fireItems[i].SetActive(true);
            }

        }
        for (int i = 0; i < GameObject.FindWithTag("PetDono").GetComponent<Inventory>().GetMeat(); i++)
        {
            if(i < meatItems.Length)
            {
                meatItems[i].SetActive(true);
            }

        }
    }

    //=================================================================
    //-------------------------------------btn functions --------------
    //=================================================================
    public void RestartGameBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
