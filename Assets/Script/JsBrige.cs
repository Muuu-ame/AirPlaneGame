using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
public class JsBrige : MonoBehaviour
{
    public void OnBackButtonClick()
    {
        Debug.Log("Unity: OnBackButtonClick called");
#if UNITY_WEBGL && !UNITY_EDITOR
        Application.ExternalEval("window.parent.postMessage({ type: 'BackButton' }, '*');");
#else
        Debug.Log("BackButton (Editor stub)");
#endif
    }
    public void OnNextButtonClick()
    {
        Debug.Log("Unity: OnNextButtonClick called");
#if UNITY_WEBGL && !UNITY_EDITOR
        Application.ExternalEval("window.parent.postMessage({ type: 'NextButton' }, '*');");
#else
        Debug.Log("NextButton (Editor stub)");
#endif
    }
    public void retry()
    {
        Debug.Log("Unity: retry called");
        SceneManager.LoadScene("Game");
    }
}