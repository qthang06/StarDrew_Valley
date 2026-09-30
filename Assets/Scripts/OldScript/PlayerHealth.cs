using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public Slider sld;
    public TMP_Text healthText;
    public Animator healthTextAnim;

    private void Start()
    {
        healthText.text = "Health: " + currentHealth + " / " + maxHealth;
        sld.maxValue = maxHealth;
        sld.value = currentHealth;
    }
    public void TakeDamage(int amount)
    {
        currentHealth += amount;
        healthTextAnim.Play("HealthText");
        healthText.text = "Health: " + currentHealth + " / " + maxHealth;
        sld.value = currentHealth;
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
