using System.Collections.Generic;
using UnityEngine;

public class ChildParticlesScaler : MonoBehaviour
{
    float scale;
    var particles = new List<ParticleSystem>();

    void OnEnable()
    {
        scale = transform.localScale.x;
        GetComponentsInChildren(true, particles);
        foreach (var ps in particles)
            ps.transform.localScale *= scale;
    }

    void Update()
    {
        if (transform.hasChanged)
        {
            var curScale = transform.localScale.x;
            foreach (var ps in particles)
                ps.transform.localScale *= curScale / scale;
            scale = curScale;
            transform.hasChanged = false;
        }
    }
}
