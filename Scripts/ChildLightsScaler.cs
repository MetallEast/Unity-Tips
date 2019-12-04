// Same as the ChildParticlesScaler, but instead of localScale, Light.range changes

using System.Collections.Generic;
using UnityEngine;

public class ChildLightsScaler : MonoBehaviour
{
    float scale;
    List<Light> lights = new List<Light>();

    void OnEnable()
    {
        scale = transform.localScale.x;
        GetComponentsInChildren(true, lights);
        foreach (Light light in lights)
            light.range *= scale;
    }

    void Update()
    {
        if (transform.hasChanged)
        {
            float curScale = transform.localScale.x;
            foreach (Light light in lights)
                light.range *= curScale / scale;
            scale = curScale;
            transform.hasChanged = false;
        }
    }
}