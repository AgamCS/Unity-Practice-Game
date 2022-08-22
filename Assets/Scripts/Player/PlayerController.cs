using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController _instance;
    public static PlayerController Instance {get {return _instance;}}

    [SerializeField] float walkSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] float gravity;   
    [SerializeField] LayerMask groundLayer;

    public bool Sprinting = false;
    public bool SwitchingWeapons = false;
    public bool Shooting = false;
    public bool Reloading = false;

    float slopeForce;
    float slopeForceRayLength;
    
    Vector3 velocity;
    CharacterController controller;

    // Lock cursor to game and get character controller reference
    void Start()
    {
        controller = GetComponent<CharacterController>(); 
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Create an instance of this class if one does not exist, if one does, then destory this object
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    
    void Update()
    {
        UpdateMovement(); 
    }

    void UpdateSprint()
    {
        if (Input.GetButton("Sprint"))
        {
            Sprinting = true;
        }
        else
        {
            Sprinting = false;
        }
    }

    // Update movement by getting only the horizontal movement, since we're in 2d space.
    void UpdateMovement()
    {
        UpdateSprint();
        
        float targetDir = Input.GetAxisRaw("Horizontal");
        velocity.y += gravity * Time.deltaTime;
        velocity = (transform.right * targetDir) * (Sprinting ? sprintSpeed : walkSpeed) + Vector3.up * velocity.y;
        controller.Move(velocity * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
    }

}

    