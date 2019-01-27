using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Home : MonoBehaviour, _Interactable
{
    public float waterHealth = 100;
    public float fireHealth = 100;
    public float meatHealth = 100;

    float currentWaterHealth = 100;
    float currentFireHealth = 100;
    float currentMeatHealth = 100;

    public Image currentWaterHealthBar;
    public Image currentFireHealthBar;
    public Image currentMeatHealthBar;


    public void interactWith()
    {
        print("current water" + GameObject.FindWithTag("PetDono").GetComponent<Inventory>().GetWater());
        print("current fire" + GameObject.FindWithTag("PetDono").GetComponent<Inventory>().GetFire());
        print("current meat" + GameObject.FindWithTag("PetDono").GetComponent<Inventory>().GetMeat());
        //restore home values
        currentWaterHealth += GameObject.FindWithTag("PetDono").GetComponent<Inventory>().GetWater() * 10;
        currentFireHealth += GameObject.FindWithTag("PetDono").GetComponent<Inventory>().GetFire() * 10;
        currentMeatHealth += GameObject.FindWithTag("PetDono").GetComponent<Inventory>().GetMeat() * 10;

        print("added water" + GameObject.FindWithTag("PetDono").GetComponent<Inventory>().GetWater() * 10);
        print("added fire" + GameObject.FindWithTag("PetDono").GetComponent<Inventory>().GetFire() * 10);
        print("added meat" + GameObject.FindWithTag("PetDono").GetComponent<Inventory>().GetMeat() * 10);

        print("current added water " + currentWaterHealth);
        print("current added fire " + currentFireHealth);
        print("current added meat " + currentMeatHealth);

        // clamping values
        if (currentWaterHealth > 100)
            currentWaterHealth = 100;
        if (currentFireHealth > 100)
            currentFireHealth = 100;
        if (currentMeatHealth > 100)
            currentMeatHealth = 100;

        print("after clamp =======================");
        print("current added water " + currentWaterHealth);
        print("current added fire " + currentFireHealth);
        print("current added meat " + currentMeatHealth);

        GameObject.FindWithTag("CustomAudioManager").GetComponent<CustomAudioManager>().addItemToBase.Play();

        //reset all values
        GameObject.FindWithTag("PetDono").GetComponent<Inventory>().ResetAll();


    }

    // Update is called once per frame
    void Update()
    {
        //comsume food contantly
        currentWaterHealth -= Time.deltaTime;
        currentFireHealth -= Time.deltaTime;
        currentMeatHealth -= Time.deltaTime;

        //set ui
        currentWaterHealthBar.fillAmount = currentWaterHealth / waterHealth;
        currentFireHealthBar.fillAmount = currentFireHealth / fireHealth;

        currentMeatHealthBar.fillAmount = currentMeatHealth / meatHealth;

        if(currentWaterHealth <= 0 || currentFireHealth <= 0 || currentMeatHealth <= 0)
        {
            GameObject.FindWithTag("UiManager").GetComponent<CustomUiManager>().ShowDeathCanvas();
        }

    }

    public int GetInteractType()
    {
        return 0;
    }
}
