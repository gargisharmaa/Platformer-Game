using UnityEngine;

public class Enemy_Sideways : MonoBehaviour
{
    [SerializeField] private float movementDistance; // Distance the enemy will move left and right
    [SerializeField] private float speed; // Movement speed of the enemy
    [SerializeField] private float damage; // Damage dealt to the player on collision
    private bool movingLeft; // Flag to track the current movement direction
    private float leftEdge; // Leftmost position where the enemy can move
    private float rightEdge; // Rightmost position where the enemy can move

    private void Awake()
    {
        // Calculate the left and right edge positions based on the initial position and movement distance
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                // Move the enemy to the left
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingLeft = false;
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                // Move the enemy to the right
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingLeft = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Damage the player on collision
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
