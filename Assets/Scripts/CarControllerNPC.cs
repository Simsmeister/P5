using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerNPC : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentbreakForce;
    private bool isBreaking;
    public string spawnPointTag;
    public GameObject spawnPoint;
    public CarSpawner carSpawner;

    public GameObject lastCar;
    

    // Settings
    [SerializeField] private float motorForce, breakForce, maxSteerAngle;

    // Wheel Colliders
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // Wheels
    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;


    private void Start()
    {
        
    }


    private void FixedUpdate() {
        //GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        if (lastCar == null)
        {
            // If not, obtain a new reference
            spawnPoint = GameObject.FindGameObjectWithTag(spawnPointTag);
            carSpawner = spawnPoint.GetComponent<CarSpawner>();
            lastCar = carSpawner.GetLastInstantiatedCar();
            Debug.Log(carSpawner.name);
        }

        if (lastCar != null)
        {
            IntervalNPC variables = lastCar.GetComponent<IntervalNPC>();

            motorForce = variables.motorForceSent;
            breakForce = variables.breakForceSent;
            horizontalInput = variables.horizontalInputSent;
            verticalInput = variables.verticalInputSent;

        Debug.Log(variables.motorForceSent);
        }
        else
        {
            // Handle the case where lastCar is null, e.g., log an error or take appropriate action
            Debug.LogError("lastCar is null. Cannot update variables.");
        }
    }

    private void GetInput() {
        // Steering Input
        horizontalInput = Input.GetAxis("Horizontal");

        // Acceleration Input
        verticalInput = Input.GetAxis("Vertical");

        // Breaking Input
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void Update()
    {

        /*if (lastCar == null)
        {
            // If not, obtain a new reference
            spawnPoint = GameObject.FindGameObjectWithTag(spawnPointTag);
            carSpawner = spawnPoint.GetComponent<CarSpawner>();
            lastCar = carSpawner.GetLastInstantiatedCar();
            Debug.Log(carSpawner.name);
        }

        if (lastCar != null)
        {
            IntervalNPC variables = lastCar.GetComponent<IntervalNPC>();

            motorForce = variables.motorForceSent;
            breakForce = variables.breakForceSent;
            horizontalInput = variables.horizontalInputSent;
            verticalInput = variables.verticalInputSent;

        Debug.Log(variables.motorForceSent);
        }
    else
    {
        // Handle the case where lastCar is null, e.g., log an error or take appropriate action
        Debug.LogError("lastCar is null. Cannot update variables.");
    }

        /*IntervalScript variables = lastCar.GetComponent<IntervalScript>(); 

        motorForce = variables.motorForceSent; 
        breakForce = variables.breakForceSent;
        horizontalInput = variables.horizontalInputSent;
        verticalInput = variables.verticalInputSent;

        Debug.Log(variables.motorForceSent);*/
    }

    private void HandleMotor() {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking() {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering() {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels() {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform) {
        Vector3 pos;
        Quaternion rot; 
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}