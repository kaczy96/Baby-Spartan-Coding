using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geyser : MonoBehaviour
{
    ParticleSystem GeyserParticleSystem;
    void Start()
    {
        GeyserParticleSystem = GetComponent<ParticleSystem>();
        StartCoroutine("Working");
    }

    public IEnumerator Working()
    {
        GeyserParticleSystem.Play();
        yield return new WaitForSeconds(5f);
        StartCoroutine("NotWorking");
    }
    public IEnumerator NotWorking()
    {
        GeyserParticleSystem.Stop();
        yield return new WaitForSeconds(5f);
        StartCoroutine("Working");
    }



}
       



