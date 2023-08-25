using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;     // Reference to the player's Health script
    [SerializeField] private Image totalhealthBar;    // Reference to the total health bar image
    [SerializeField] private Image currenthealthBar;  // Reference to the current health bar image

    private void Start()
    {
        // Initialize the total health bar fill amount based on the player's starting health
        totalhealthBar.fillAmount = playerHealth.currentHealth / playerHealth.startingHealth;
    }

    private void Update()
    {
        // Update the current health bar fill amount based on the player's current health
        currenthealthBar.fillAmount = playerHealth.currentHealth / playerHealth.startingHealth;
    }
}
