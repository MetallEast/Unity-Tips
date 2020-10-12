using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FontBalancer : MonoBehaviour
{
    [SerializeField] bool isSelfDestroy;
    [SerializeField] Text[] texts;

    IEnumerator Start()
    {
        if (texts.Length < 2)
            yield break;
        yield return null;

        int minSize = int.MaxValue;
        foreach (var t in texts)
        { 
            if (minSize > t.cachedTextGenerator.fontSizeUsedForBestFit)
                minSize = t.cachedTextGenerator.fontSizeUsedForBestFit;
        }

        foreach (var t in texts)
        {
            t.resizeTextMaxSize = minSize;
        }

        if (isSelfDestroy)
            Destroy(this);
    }
}