using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    [SerializeField] float destroyAfterTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyAfterTime);
    }

}
