using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtestorScript : MonoBehaviour
{
    void Start()
    {
        // Rotate to random y-angle
        transform.rotation = Quaternion.Euler(0.0f, Random.Range(-180.0f, 180.0f),0.0f);

        // Move backward a random amount
        transform.position = -transform.forward.normalized * Random.Range(0.5f, 3.0f);
    }
}
