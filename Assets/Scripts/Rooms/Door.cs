using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom; // Reference to the previous room's transform
    [SerializeField] private Transform nextRoom; // Reference to the next room's transform
    [SerializeField] private CameraController cam; // Reference to the CameraController script

    private void Awake()
    {
        // Get the CameraController script attached to the main camera
        cam = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
            {
                // Move camera to the next room's position
                cam.MoveToNewRoom(nextRoom);
                // Activate the next room and deactivate the previous room
                nextRoom.GetComponent<Room>().ActivateRoom(true);
                previousRoom.GetComponent<Room>().ActivateRoom(false);
            }
            else
            {
                // Move camera to the previous room's position
                cam.MoveToNewRoom(previousRoom);
                // Activate the previous room and deactivate the next room
                previousRoom.GetComponent<Room>().ActivateRoom(true);
                nextRoom.GetComponent<Room>().ActivateRoom(false);
            }
        }
    }
}
