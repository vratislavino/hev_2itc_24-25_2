using System;
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
            SpawnTower();
        }
    }

    private void SpawnTower()
    {
        var tower = Instantiate(TdWaypointProvider.Instance.TowerPrefab, transform.position, Quaternion.identity);
        tower.transform.SetParent(transform);
        tower.transform.localPosition = Vector3.zero;
        tower.transform.localScale = Vector3.one;
    }
}
