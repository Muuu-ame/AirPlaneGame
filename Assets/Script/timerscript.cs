using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using random = UnityEngine.Random;
using System.Collections;

public class timerscript : MonoBehaviour
{
    private float timer = 0f;
    private float timerMax = 0f;

    public TMP_Text timerText;
    public TMP_Text missionText;
    public Button eventButton;

    public Object byoudetyakurikuseyo3;

    void Start()
    {
        timer = 0;
        timerMax = random.Range(25f, 40f);

        // 最初はボタンを押せないようにする
        eventButton.interactable = false;

        // 3秒後にゲーム開始
        StartCoroutine(StartGame());
    }

    void Update()
    {
        // ゲーム開始前はタイマーを進めない
        if (!eventButton.interactable)
            return;

        timer += Time.deltaTime;

        timerText.text = Mathf.CeilToInt(timer).ToString();
    }

    IEnumerator StartGame()
    {
        // 制限時間を表示
        missionText.text = Mathf.CeilToInt(timerMax).ToString();

        // 3秒待つ
        yield return new WaitForSeconds(3f);

        Destroy(byoudetyakurikuseyo3);    

        // 指示を消す
        missionText.text = "";

        // タイマー開始
        timer = 0f;

        // ボタンを押せるようにする
        eventButton.interactable = true;
    }

    // ボタンを押したとき
    public void EventButton()
    {
        if (timer < timerMax - 2)
        {
            hayasugiEvent();
        }
        else if (timer <= timerMax + 2)
        {
            ClearButton();
        }
        else
        {
            ososugiEvent();
        }
    }
    public void ClearButton()
    {
        SceneManager.LoadScene("Clear");
    }

    public void hayasugiEvent()
    {
        SceneManager.LoadScene("hayai");
    }

    public void ososugiEvent()
    {
        SceneManager.LoadScene("osoi");
    }
}

