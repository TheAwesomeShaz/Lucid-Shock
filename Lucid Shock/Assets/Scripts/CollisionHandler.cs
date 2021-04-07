using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    public GameObject explosionVFX;

    private int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCrashSequence(other);
    }

    private void StartCrashSequence(Collider other)
    {
        var explodeFX = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(explodeFX, 1f);

        GetComponent<Renderer>().enabled = false;

        GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<PlayerControls>().enabled = false;
        Debug.Log(this.name + " TRIGGERED by " + other.gameObject.name);
        Invoke(nameof(ReloadLevel), loadDelay);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
}
