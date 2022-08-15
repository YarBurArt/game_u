﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private Transform transformFL;
    [SerializeField] private Transform transformFR;
    [SerializeField] private Transform transformBL;
    [SerializeField] private Transform transformBR;

    [SerializeField] private WheelCollider colliderFL;
    [SerializeField] private WheelCollider colliderFR;
    [SerializeField] private WheelCollider colliderBL;
    [SerializeField] private WheelCollider colliderBR;

    [SerializeField] private float force;
    [SerializeField] private float maxAngle;
    private void FixedUpdate()
    {
        colliderFL.motorTorque = Input.GetAxis("Vertical") * force;
        colliderFR.motorTorque = Input.GetAxis("Vertical") * force;

        if (Input.GetKey(KeyCode.Space))
        {
            colliderFL.brakeTorque = 3000f;
            colliderFR.brakeTorque = 3000f;
            colliderBL.brakeTorque = 3000f;
            colliderBR.brakeTorque = 3000f;
        }
        else
        {
            colliderFL.brakeTorque = 0f;
            colliderFR.brakeTorque = 0f;
            colliderBL.brakeTorque = 0f;
            colliderBR.brakeTorque = 0f;
        }

        colliderFL.steerAngle = maxAngle * Input.GetAxis("Horizontal");
        colliderFR.steerAngle = maxAngle * Input.GetAxis("Horizontal");

        RotateWheel(colliderFL, transformFL);
        RotateWheel(colliderFR, transformFR);
        RotateWheel(colliderBL, transformBL);
        RotateWheel(colliderBR, transformBR);
    }

    private void RotateWheel(WheelCollider collider, Transform transform)
    {
        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);

        transform.position = position;
        transform.rotation = rotation;

    }
}
