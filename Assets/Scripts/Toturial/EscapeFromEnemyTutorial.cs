using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EscapeFromEnemyTutorial : MonoBehaviour, Instruction
{
    private bool completed = false;
    public bool Completed
    {
        get => completed;
    }

    string counterLife;
    [SerializeField] TextMeshProUGUI lifePointsText;


    void Start()
    {
        // Get the TextMeshPro component from the GameObject

        counterLife = lifePointsText.text;
       // Debug.Log("lifePointsText" + counterLife);


    }

    private void Update()
    {
        counterLife = lifePointsText.text;


        if (counterLife == "1")
        {
         //   Debug.Log("lifePointsText" + counterLife);

            completed = true;
            // manager.BambooIsFinished();
        }
    }
}
