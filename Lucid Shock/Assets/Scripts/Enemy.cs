using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform runtimeParent;

    private void Start()
    {
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider()
    {
        if (!gameObject.GetComponent<BoxCollider>())
        {
            gameObject.AddComponent<BoxCollider>();
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    private void OnParticleCollision(GameObject other)
    {

        print("Particles collided with enemy " + gameObject.name);

        //particle FX
        GameObject deathParticles = Instantiate(deathVFX, transform.position, Quaternion.identity) as GameObject;
        deathParticles.transform.parent = runtimeParent;

        //Score Logic
        FindObjectOfType<ScoreBoard>().ScoreHit();

        //Cleaning
        Destroy(gameObject);
    }
}
