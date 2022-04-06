using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(InputManager))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [HideInInspector]public NavMeshAgent agent;
    [HideInInspector]public Animator anim;
    [HideInInspector]public InputManager inputManager;


    public float MovementSpeed ;
    public float RotationSpeed ;



    [SerializeField]
    private Camera Camera;

    public bool canMove = true;


    

    private void Start()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
        agent = GetComponent<NavMeshAgent>();
        inputManager = GetComponent<InputManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {

            MovementSpeed = 4;
            RotationSpeed = 10;
        
        var targetVector = new Vector3(inputManager.InputVector.x, 0, inputManager.InputVector.y);

        // Move in the direction we are aiming
        var movementVector = MoveTowardTarget(targetVector);

        //Rotate in the direction we are traveling
        RotateTowardMovementVector(movementVector);

        anim.SetFloat("vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal"));
        }
        else
        {
            
            MovementSpeed = 0;
            RotationSpeed = 0;
            anim.SetFloat("vertical", 0);
            anim.SetFloat("horizontal", 0);

           
        }

    }

    private void RotateTowardMovementVector(Vector3 movementVector)
    {
        if (movementVector.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed);
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = MovementSpeed * Time.deltaTime;
      

        targetVector = Quaternion.Euler(0, Camera.gameObject.transform.rotation.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }

   
}