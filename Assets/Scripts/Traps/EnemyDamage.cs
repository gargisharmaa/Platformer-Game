using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected float damage; // Amount of damage this enemy deals

    // This method is called when this object's collider triggers with another collider
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Get the Health component of the collided player and apply damage
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
