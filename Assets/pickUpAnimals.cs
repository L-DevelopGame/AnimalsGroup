using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]

public class pickUpAnimals : MonoBehaviour
{

    private List<string> pickedAnimals = new List<string>();

    public void AddAnimal(string animalName)
    {
        pickedAnimals.Add(animalName);
    }

    public List<string> GetPickedAnimals()
    {
        return pickedAnimals;
    }


}




