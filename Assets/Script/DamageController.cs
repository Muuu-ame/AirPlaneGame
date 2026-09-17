using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DamageController : MonoBehaviour
{
    public float HP = 3f;

    public Image hpBar;

    private void Start()
    {
        UpdateHPBar();
    }

    public void TakeDamage(float damageAmount)
    {
        HP -= damageAmount;

        Debug.Log("ダメージを受けた。残りHP: " + HP);

        UpdateHPBar();

        if (HP <= 0)
        {
            Die();
        }
    }

    private void UpdateHPBar()
    {
        hpBar.fillAmount = HP / 3f;
    }

    private void Die()
    {
        Debug.Log("Player has died.");
        SceneManager.LoadScene("hayai");
    }
}