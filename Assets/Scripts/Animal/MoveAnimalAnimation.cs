using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimalAnimation : MoveAndFlipAnimal
{
    Animator animalAnimator = null;

    private void Start()
    {
        // movingRight = true;

        animalAnimator = this.GetComponent<Animator>();
        animalAnimator.SetInteger("Run", 1);



    }





}
