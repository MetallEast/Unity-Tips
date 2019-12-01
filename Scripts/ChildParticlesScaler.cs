using System.Collections.Generic;
using UnityEngine;

public class ChildParticlesScaler : MonoBehaviour
{
    float scale;
    List<ParticleSystem> particles = new List<ParticleSystem>();

    void Awake()
    {
        scale = transform.localScale.x;
        particles.AddRange(Resources.FindObjectsOfTypeAll(typeof(ParticleSystem)) as ParticleSystem[]);
        foreach (ParticleSystem ps in particles)
            ps.transform.localScale *= scale; 
    }

    void Update()
    {
        if (transform.hasChanged)
        {
            float curScale = transform.localScale.x;
            foreach (ParticleSystem ps in particles)
                ps.transform.localScale *= curScale / scale;
            scale = curScale;
            transform.hasChanged = false;
        }
    }
}
