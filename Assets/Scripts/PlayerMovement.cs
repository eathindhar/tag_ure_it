using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float chaserSpeed = 6f;
    public float runnerSpeed = 5f;

    public float speed = 5f;
    private Vector2 movement;


    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.zero;

        if (Keyboard.current.aKey.isPressed)
            movement.x = -1;
        else if (Keyboard.current.dKey.isPressed)
            movement.x = 1;

        if (Keyboard.current.sKey.isPressed)
            movement.y = -1;
        else if (Keyboard.current.wKey.isPressed)
            movement.y = 1;

        transform.Translate(movement * Time.deltaTime * 5f);
    }
}
