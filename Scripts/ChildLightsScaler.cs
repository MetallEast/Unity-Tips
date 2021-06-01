// Same as the ChildParticlesScaler, but instead of localScale, Light.range changes

using System.Collections.Generic;
using UnityEngine;

public class ChildLightsScaler : MonoBehaviour
{
    float scale;
    var lights = new List<Light>();

    void OnEnable()
    {
        scale = transform.localScale.x;
        GetComponentsInChildren(true, lights);
        foreach (var light in lights)
            light.range *= scale;
    }

    void Update()
    {
        if (transform.hasChanged)
        {
            var curScale = transform.localScale.x;
            foreach (var light in lights)
                light.range *= curScale / scale;
            scale = curScale;
            transform.hasChanged = false;
        }
    }
}
