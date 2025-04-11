using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    public CharacterController playerController;

    // Update is called once per frame
    void FixedUpdate()
    {
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");

        Vector3 playerMovement = transform.right * movX + transform.forward * movZ;

        playerController.Move(playerMovement * speed);
    }
}
