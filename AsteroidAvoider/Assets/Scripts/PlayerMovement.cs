using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forceMagnitude;
    [SerializeField] float maxVelocity;
    Rigidbody playerRB;
    Camera mainCamera;
    Vector3 movementDirection;
    void Start()
    {
        mainCamera = Camera.main;
        playerRB = GetComponent<Rigidbody>();
    }
    void Update()
    {
        DisplayTouchCoordinates();
    }
    void DisplayTouchCoordinates(){
        if(Touchscreen.current.primaryTouch.press.isPressed){
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
            
            movementDirection = worldPosition - transform.position;
            movementDirection.z = 0f;
            movementDirection.Normalize();
        }
        else{
            movementDirection = Vector3.zero;
        }
    }
    void FixedUpdate() {
        if(movementDirection == Vector3.zero){return;}
        playerRB.AddForce(movementDirection * forceMagnitude, ForceMode.Force);
        playerRB.velocity = Vector3.ClampMagnitude(playerRB.velocity, maxVelocity);
    }
}
