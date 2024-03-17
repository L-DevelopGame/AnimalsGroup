using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExplainGame : MonoBehaviour
{
    public TextMeshProUGUI instructionText;
    private bool welcomeCompleted = false;
    private bool moveKeyboardCompleted = false;
    private bool askUserToPickAnimalCompleted = false;
    private bool pickWrongAnimalCompleted = false;
    private bool carefullTouchFireAndTrapsCompleted = false;

    void Start()
    {
        StartCoroutine(ShowWelcomeText());
    }

    IEnumerator ShowWelcomeText()
    {
        instructionText.text = "Hi, Welcome! \n (press Space To Continue)";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        instructionText.text = "";
        welcomeCompleted = true;
        StartCoroutine(ShowMoveKeyboardText());
    }

    IEnumerator ShowMoveKeyboardText()
    {
        instructionText.text = "Move the keyboard to play: Left,Right,Up,Down \n (press Space To Continue)";
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        instructionText.text = "";
        moveKeyboardCompleted = true;
        StartCoroutine(AskUserToPickAnimal());
    }

    IEnumerator AskUserToPickAnimal()
    {
        instructionText.text = "Great ! Now pick an animal according to the desired category on the side of the screen \n (press Space To Continue)";
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        instructionText.text = "";
        askUserToPickAnimalCompleted = true;
        StartCoroutine(PickWrongAnimalOrFire());
    }

    IEnumerator PickWrongAnimalOrFire()
    {
        instructionText.text = "Picking up an animal that doesn't fit the category will deduct you from the number of lives shown above+\n + (press Space To Continue)";
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        instructionText.text = "";
        pickWrongAnimalCompleted = true;
        StartCoroutine(CarefullTouchFireAndTraps());
    }

    IEnumerator CarefullTouchFireAndTraps()
    {
        instructionText.text = "In addition, be careful not to touch fire and keep a distance from the bull man's enemy. Enjoy!";
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(5f); // Wait for 5 seconds
        instructionText.text = "";
        carefullTouchFireAndTrapsCompleted = true;
    }

    void Update()
    {
        if (welcomeCompleted && moveKeyboardCompleted && askUserToPickAnimalCompleted && pickWrongAnimalCompleted && carefullTouchFireAndTrapsCompleted)
        {
            // All steps completed, do something else here if needed
        }
    }
}
