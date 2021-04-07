using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int hitPoints = 5;
    [SerializeField] int scorePerHit;
    [SerializeField] GameObject explosionVFX;
    [SerializeField] GameObject hitVFX;
    ScoreBoard scoreBoard;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        gameObject.AddComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints < 1)
            KillEnemy();

        Debug.Log(this.name + " was killed \n Current Score is :" + scoreBoard.score);
    }

    private void KillEnemy()
    {
        var explodeFX = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }



    private void ProcessHit()
    {
        hitPoints--;
        var hitFX = Instantiate(hitVFX, transform.position, Quaternion.identity);
        scoreBoard.IncreaseScore(scorePerHit);
    }
}
