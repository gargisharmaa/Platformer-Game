using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Room Camera")]
    [SerializeField] private float speed; // Speed of camera movement between rooms
    private float currentPosX; // Current target X position of the camera
    private Vector3 velocity = Vector3.zero; // Velocity for smoothing camera movement

    [Header("Follow Player")]
    [SerializeField] private Transform player; // Reference to the player's transform
    [SerializeField] private float aheadDistance; // Distance ahead of the player to focus on
    [SerializeField] private float cameraSpeed; // Speed of camera movement when following the player
    private float lookAhead; // Calculated distance to look ahead of the player

    private void Update()
    {
        // Room camera movement using SmoothDamp for smooth transitions
        transform.position = Vector3.SmoothDamp(
            transform.position,
            new Vector3(currentPosX, transform.position.y, transform.position.z),
            ref velocity,
            speed
        );

        // Uncomment the following lines for player-following camera
        // Calculate the desired look ahead distance
        // lookAhead = Mathf.Lerp(lookAhead, aheadDistance * player.localScale.x, Time.deltaTime * cameraSpeed);
        // Update camera position to follow the player horizontally
        // transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
    }

    // Method to move the camera to a new room's X position
    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
