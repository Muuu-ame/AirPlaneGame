using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnimationText : MonoBehaviour
{
    public Animator animator;
    public TMP_Text text;
    public Button NextButton;
    public Button OneMoreButton;

    void Start()
    {
        text.gameObject.SetActive(false);

        NextButton.gameObject.SetActive(false); 
        OneMoreButton.gameObject.SetActive(false);

        animator.Play("AnimationName");


        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {

        yield return new WaitForSeconds(2.9f);

        animator.speed = 0f;

        yield return new WaitForSeconds(1f);

        text.gameObject.SetActive(true);

        NextButton.gameObject.SetActive(true);
        OneMoreButton.gameObject.SetActive(true);
    }
}

