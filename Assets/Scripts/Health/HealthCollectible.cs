using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue; // Amount of health to add on collection

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Get the Health component from the collided player
            Health playerHealth = collision.GetComponent<Health>();

            if (playerHealth != null) // Make sure the player has the Health component
            {
                playerHealth.AddHealth(healthValue); // Add health to the player
                gameObject.SetActive(false); // Deactivate the health collectible
            }
        }
    }
}
