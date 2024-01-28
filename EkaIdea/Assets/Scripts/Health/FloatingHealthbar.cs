using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthbar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public Health bossHealth;
    [SerializeField] public float maxHealth;

    private void Start()
    {
        // Ensure that the boss's Health component is assigned.
        if (bossHealth == null)
        {
            Debug.LogError("Boss's Health component is not assigned to the FloatingHealthbar script.");
            enabled = false; // Disable this script if not properly configured.
        }
    }

    private void Update()
    {
        UpdateHealthbar();
    }

    public void UpdateHealthbar()
    {
        // Ensure the bossHealth component is valid.
        if (bossHealth == null)
            return;

        // Update the health bar based on the boss's health.
        float currentHealth = bossHealth.currentHealth;
       

        // Update the slider value.
        slider.value = currentHealth / maxHealth;
    }
}
