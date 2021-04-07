using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControls : MonoBehaviour
{

    [Header("Input Controls related Stuff")]

    [Tooltip("Speed of the ship moving left and right")]
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 3.5f;
    [SerializeField] float xThrow;
    [SerializeField] float yThrow;

    [Header("Position Based Tuning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -2f;

    [Header("Player Input Based Tuning")]
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = 2f;
    [Header("LaserGun Array")]
    [SerializeField] GameObject[] lasers;
    // Start is called before the first frame update
    void Start()
    {
        SetLasersActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotation();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }


    private void SetLasersActive(bool isActive)
    {
        foreach (var laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

    private void Rotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float yawDueToPostion = transform.localPosition.x * positionYawFactor;
        float rollDueToControlThrow = xThrow * controlRollFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = yawDueToPostion;

        float roll = rollDueToControlThrow;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void Movement()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float yOffset = yThrow * Time.deltaTime * controlSpeed;

        float newXpos = transform.localPosition.x + xOffset;
        float newYpos = transform.localPosition.y + yOffset;

        float clampedXpos = Mathf.Clamp(newXpos, -xRange, xRange);
        float clampedYpos = Mathf.Clamp(newYpos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
    }
}
