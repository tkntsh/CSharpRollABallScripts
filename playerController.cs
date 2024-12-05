using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    //movement speed
    public float speed = 10f;
    private Rigidbody rb;
    //movement inputs
    private Vector2 movementInput;

    //when game starts rigidbody of player object is collected and stored
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //WASD input and move the player
        movePlayer();
    }

    //method to detect what time of movement should happen using input from keyboard
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    //method to move player
    private void movePlayer()
    {
        Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}

