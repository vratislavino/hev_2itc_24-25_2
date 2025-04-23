using UnityEngine;

public class TdTile : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Color normalColor;
    [SerializeField]
    Color highlightColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        normalColor = spriteRenderer.color;
        /*highlightColor = new Color(
            normalColor.r, 
            normalColor.g, 
            normalColor.b,
            0.5f
            );*/
    }

    private void OnMouseEnter()
    {
        spriteRenderer.color = highlightColor;
    }

    private void OnMouseExit()
    {
        spriteRenderer.color = normalColor;
    }

    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked on tile: " + gameObject.name);
        }
    }
}
