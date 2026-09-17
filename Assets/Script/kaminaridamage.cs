using UnityEngine;

public class kaminaridamage : MonoBehaviour
{
    public float damageAmount = 1f;

    private bool hasDamaged = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (hasDamaged)
            return;

        hasDamaged = true;

        DamageController DC = other.GetComponent<DamageController>();

        if (DC != null)
        {
            DC.TakeDamage(damageAmount);
        }
        else
        {
            Debug.LogWarning("Player Ç… DamageController Ç™Ç†ÇËÇ‹ÇπÇÒÅB");
        }

        Collider2D col = GetComponent<Collider2D>();

        if (col != null)
            col.enabled = false;
    }
}