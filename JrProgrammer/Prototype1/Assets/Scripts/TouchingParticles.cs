using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingParticles : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem ParticlesSys;
    private bool Once = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Vehicle" && Once)
        {
            ParticlesSys.Play();
            Once = false;
        }
    }

}
