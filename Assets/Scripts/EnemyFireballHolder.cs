using UnityEngine;

public class EnemyFireballHolder : MonoBehaviour
{
    [SerializeField] private Transform enemy; // Reference to the enemy's transform

    private void Update()
    {
        // Set the local scale of the fireball holder to match the enemy's local scale
        transform.localScale = enemy.localScale;
    }
}
