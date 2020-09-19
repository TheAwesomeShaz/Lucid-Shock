using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;


    private void OnTriggerEnter(Collider other)
    {
        print("Collision Occured Boiiii");

        StartDeath();
    }

    private void StartDeath()
    {
        SendMessage("OnPlayerDeath");
    }
}
