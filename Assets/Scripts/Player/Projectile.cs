using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private float lifetime;

    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        // Get references to Animator and BoxCollider2D components
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit) return; // If the projectile has hit, no need to update its position

        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0); // Move the projectile horizontally

        lifetime += Time.deltaTime;
        if (lifetime > 5) gameObject.SetActive(false); // Deactivate the projectile after its lifetime
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true; // Projectile has hit something
        boxCollider.enabled = false; // Disable the collider to prevent further collisions
        anim.SetTrigger("explode"); // Trigger the explosion animation

        if (collision.tag == "Enemy")
            collision.GetComponent<Health>().TakeDamage(1); // Damage the enemy
    }

    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false); // Deactivate the projectile
    }
}
