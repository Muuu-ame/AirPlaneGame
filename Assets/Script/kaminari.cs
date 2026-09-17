using System.Collections;
using UnityEngine;

public class kaminari : MonoBehaviour
{
    public Vector2[] spawnPositions;

    public GameObject thunderPrefab;           // —‹–{‘Ì
    public GameObject thunderWarningPrefab;    // 1‰ñ–Ú‚ÌŒx
    public GameObject thunderWarning2Prefab;   // 2‰ñ–Ú‚ÌŒxiAnimator•t‚«j

    public float spawnInterval = 3f;
    public float spawnIntervalDecrease = 0.02f;

    public float firstWarningDuration = 1f;     // 1‰ñ–Ú‚ÌŒxŽžŠÔ
    public float secondWarningDuration = 1f;    // 2‰ñ–Ú‚ÌŒxŽžŠÔ
    public float thunderDuration = 0.1f;        // —‹‚ª—Ž‚¿‚éŽžŠÔ

    public float spawnOffsetY = 0f;


    private Coroutine spawnRoutine;
    public float initialDelay = 3f; // ‰Šú’x‰„ŽžŠÔ


    void Start()
    {
        spawnRoutine = StartCoroutine(DelayedStart());
    }
    IEnumerator DelayedStart()
    {
        if (initialDelay > 0f)
            yield return new WaitForSeconds(initialDelay);

        spawnRoutine = StartCoroutine(SpawnLoop());
    }


    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnOnce();

            yield return new WaitForSeconds(spawnInterval);

            spawnInterval -= spawnIntervalDecrease;

            if (spawnInterval < 0.2f)
                spawnInterval = 0.2f;
        }
    }

    void SpawnOnce()
    {
        int idx = Random.Range(0, spawnPositions.Length);

        Vector2 pos2 = spawnPositions[idx];

        Vector3 spawnPos = new Vector3(
            pos2.x,
            pos2.y + spawnOffsetY,
            0f
        );

        StartCoroutine(ThunderSequence(spawnPos));
    }

    IEnumerator ThunderSequence(Vector3 pos)
    {
        // =====================================
        // ‡@ Å‰‚ÌŒx
        // =====================================

        GameObject warning1 = null;

        if (thunderWarningPrefab != null)
        {
            warning1 = Instantiate(
                thunderWarningPrefab,
                new Vector3(pos.x, pos.y+4.38f, pos.z),
                Quaternion.identity
            );
        }

        yield return new WaitForSeconds(firstWarningDuration);

        if (warning1 != null)
        {
            Destroy(warning1);
        }


        // =====================================
        // ‡A Šù‘¶‚ÌŒxƒAƒjƒ[ƒVƒ‡ƒ“
        // =====================================

        GameObject warning2 = null;

        if (thunderWarning2Prefab != null)
        {
            warning2 = Instantiate(
                thunderWarning2Prefab,
                pos,
                Quaternion.identity
            );
        }

        // Animator‚ª1•b‚ÅŽû‘©‚·‚é‘O’ñ
        yield return new WaitForSeconds(secondWarningDuration);

        if (warning2 != null)
        {
            Destroy(warning2);
        }


        // =====================================
        // ‡B —‹
        // =====================================

        if (thunderPrefab != null)
        {
            GameObject thunder = Instantiate(
                thunderPrefab,
                pos,
                Quaternion.identity
            );

            StartCoroutine(ThunderStrike(thunder, pos));
        }
    }

    IEnumerator ThunderStrike(GameObject thunder, Vector3 targetPos)
    {
        Vector3 startPos = targetPos + Vector3.up * 5f;

        thunder.transform.position = startPos;

        float timer = 0f;

        while (timer < thunderDuration)
        {
            timer += Time.deltaTime;

            float t = timer / thunderDuration;

            thunder.transform.position =
                Vector3.Lerp(
                    startPos,
                    targetPos,
                    t
                );

            yield return null;
        }

        thunder.transform.position = targetPos;

        Destroy(thunder);
    }

    void OnDisable()
    {
        if (spawnRoutine != null)
            StopCoroutine(spawnRoutine);
    }
}
