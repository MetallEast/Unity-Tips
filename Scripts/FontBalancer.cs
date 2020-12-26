using System.Collections;
using UnityEngine;

public class FontBalancer : MonoBehaviour
{
    [SerializeField] bool isSelfDestroy;
    [SerializeField] UnityEngine.UI.Text[] texts;

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

// Analogue for TextMeshPro
public class FontBalancer : MonoBehaviour
{
	[SerializeField] bool isSelfDestroy;
	[SerializeField] TMPro.TMP_Text[] texts;

	IEnumerator Start()
	{
		if (texts.Length < 2)
			yield break;
		yield return null;

		float minSize = int.MaxValue;
		foreach (var t in texts)
		{
			t.enableAutoSizing = false;
			if (minSize > t.fontSize)
				minSize = t.fontSize;
		}

		foreach (var t in texts)
		{
			t.fontSize = minSize;
		}

		if (isSelfDestroy)
			Destroy(this);
	}
}