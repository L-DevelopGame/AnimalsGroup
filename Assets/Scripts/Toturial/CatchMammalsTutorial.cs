using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatchMammalsTutorial : MonoBehaviour, Instruction
{


    private bool completed = false;
    public bool Completed
    {
        get => completed;
    }

    
    public GameObject scoreFieldObject; // Assign this in the Unity Editor
    private TextMeshPro scoreTextMesh;


    void Start()
    {
        // Get the TextMeshPro component from the GameObject
        scoreTextMesh = scoreFieldObject.GetComponent<TextMeshPro>();
            // Debug.Log(""+scoreTextMesh.text);


    }
    
   private void Update()
    {
       
        if (scoreTextMesh.text=="1" )
        {
            completed = true;
            // manager.BambooIsFinished();
        }
    }


}
