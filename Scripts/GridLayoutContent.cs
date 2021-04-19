using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform), (typeof(GridLayoutGroup)))]
public class GridLayoutContent : MonoBehaviour
{
    [SerializeField] int rows;
    [SerializeField] int cols;

    void Start()
    {
        RectTransform parentRect = gameObject.GetComponent<RectTransform>();
        GridLayoutGroup gridLayout = gameObject.GetComponent<GridLayoutGroup>();

        float width = parentRect.rect.width / cols;
        float height = parentRect.rect.height / rows;
        float size = width < height ? width : height;

        gridLayout.cellSize = new Vector2(size, size);
    }
}