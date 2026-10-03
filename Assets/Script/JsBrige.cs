using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JsBrige : MonoBehaviour
{
#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void SendBackButton();

    [DllImport("__Internal")]
    private static extern void SendNextButton();
#endif

    public void OnBackButtonClick()
    {
        Debug.Log("Unity: OnBackButtonClick called");

#if UNITY_WEBGL && !UNITY_EDITOR
        SendBackButton();
#else
        Debug.Log("BackButton (Editor stub)");
#endif
    }

    public void OnNextButtonClick()
    {
        Debug.Log("Unity: OnNextButtonClick called");

#if UNITY_WEBGL && !UNITY_EDITOR
        SendNextButton();
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