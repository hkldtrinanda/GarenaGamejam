using System;
using UnityEngine;
using UnityEngine.UI; // Add this line

public class Health : MonoBehaviour
{
    public static Health instance;

    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;
    
    [Header("Shield")]
    public int maxShield = 100;
    private int currentShield;

    [Header("Health Bar")]
    public float healthBarWidth = 100f;
    public Image healthBar;

    [Header("Shield Bar")]
    public float shieldBarWidth = 100f;
    public Image shieldBar;

    [Header("Audio / KO SFX")]
    public AudioSource audioSource;
    public GameObject KOText;

    [Header("Animation")]
    public Animator animator;

    private void Start()
    {
        currentHealth = maxHealth;
    }



    public void TakeDamage(int damage)
    {
        // Kurangi health sesuai dengan damage yang diterima
        currentHealth -= damage;

        animator.SetTrigger("Hurt");
        
        // Update tampilan health bar
        healthBar.fillAmount = (float)currentHealth / maxHealth;

        // Cek apakah health sudah habis
        if (currentHealth <= 0)
        {
            Die();
            audioSource.Play();
            KOText.SetActive(true);
             // Panggil fungsi Die jika health habis
        }
    }

    public void HitShield(int shield)
    {
        // Tambahkan shield sesuai dengan shield yang diterima
        currentShield -= shield;

        // Update tampilan shield bar
        shieldBar.fillAmount = (float)currentShield / maxShield;

        // Cek apakah shield sudah penuh
        if (currentShield <= maxShield)
        {
            currentShield = 0;
        }
    }

    void Die()
    {
        // Implementasikan logika kematian atau efek yang diinginkan
        Debug.Log("Objek mati!");
        animator.SetBool("Die", true);

         // Contoh: Hancurkan objek saat health habis
    }


    public void Heal(int healAmount)
    {
        // Increase health and ensure it doesn't exceed the maximum health
        currentHealth = Mathf.Clamp(currentHealth + healAmount, 0 , maxHealth);

        // Update UI
        healthBar.fillAmount = (float)currentHealth / maxHealth;
    }
}
