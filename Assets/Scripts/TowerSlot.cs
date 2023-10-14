using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TowerSlot : MonoBehaviour, IPointerClickHandler
{
    [Header("Prefab Assignment")]
    public GameObject TowerPrefab; // The tower prefab to be placed.
    [Header("Tower To Place")]
    public TowerInfo TowerInfo; // The tower info for the tower prefab.
    
    private GameObject _currentTower; // The tower currently being placed.
    private bool _isPlacing = false; // Flag to track whether a tower is being placed.

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (_isPlacing) return;
        // Create a new tower and set it as the current tower
        _currentTower = Instantiate(TowerPrefab);
        _isPlacing = true;
    }

    void Update()
    {
        // If we are placing a tower, move it with the mouse every frame
        if (_isPlacing && _currentTower != null)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _currentTower.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);

            // If the mouse is clicked, and we're not over UI, place the tower
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                _isPlacing = false;
                _currentTower.GetComponent<TowerShooter>()?.Initialize(TowerInfo);
                _currentTower = null;
            }
        }
    }
}