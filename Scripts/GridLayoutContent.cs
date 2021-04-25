using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform), (typeof(GridLayoutGroup)))]
public class GridLayoutContent : MonoBehaviour
{
    [SerializeField] int rows;
    [SerializeField] int cols;

    IEnumerator Start()
    {
		yield return new WaitForEndOfFrame();
		
        RectTransform parentRect = gameObject.GetComponent<RectTransform>();
        GridLayoutGroup gridLayout = gameObject.GetComponent<GridLayoutGroup>();

        var width = parentRect.rect.width / cols;
        var height = parentRect.rect.height / rows;
        var size = width < height ? width : height;

        gridLayout.cellSize = new Vector2(size, size);
    }
}