using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public enum Axel
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public Axel axel;
    }

    public int life;
    public float maxAcceleration = 30.0f;
    public float brakeAcceleration = 50.0f;

    public float turnSensitvity = 1.0f;
    public float maxSteeringAngle = 30.0f;

    public Vector3 _centerOfMass;

    public List<Wheel> wheels;

    public float moveInput;
    public float steerInput;

    private Rigidbody carBody;
    private Health health;

    void Start()
    {
        health = Game.health;
        carBody = GetComponent<Rigidbody>();
        carBody.centerOfMass = _centerOfMass;
    }

    void Update()
    {
        life = health.getHealth();
        GetInputs();
        AnimatedWheels();
    }

    void LateUpdate()
    {
        Drive();
        Steer();
        Brake();
    }

    void GetInputs()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }

    void Drive()
    {
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = -moveInput * maxAcceleration * Time.deltaTime;
        }
    }

    void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensitvity * maxSteeringAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }
    void Brake()
    {
        if (Input.GetKey(KeyCode.Space)|| !Input.anyKey)
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = brakeAcceleration * Time.deltaTime;
            }
        }
        else
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
            }
        }
    }

    void AnimatedWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot;
        }
    }
}
