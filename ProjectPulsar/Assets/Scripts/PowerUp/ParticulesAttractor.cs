using UnityEngine;
using System.Collections;

public class ParticulesAttractor : MonoBehaviour {

    public ParticleSystem p;
    public ParticleSystem.Particle[] particles;

    

    void Start()
    {
        
        
    }


    void Update()
    {
        if (p != null)
        {
            particles = new ParticleSystem.Particle[p.particleCount];
            p.GetParticles(particles);
            for (int i = 0; i < particles.Length; i++)
                particles[i].velocity = Vector3.Lerp(particles[i].velocity, (GameObject.FindGameObjectWithTag("Pulsar").transform.position - particles[i].position), 0.1f * 1/particles[i].startLifetime);
            p.SetParticles(particles, particles.Length);
        }
    }
   
}
