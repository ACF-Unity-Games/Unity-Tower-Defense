using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TowerSlot : MonoBehaviour, IPointerClickHandler
{
    [Header("Prefab Assignment")]
    public GameObject towerPrefab; // The tower prefab to be placed.
    
    private GameObject _currentTower; // The tower currently being placed.
    private bool _isPlacing = false; // Flag to track whether a tower is being placed.

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (_isPlacing) return;
        // Create a new tower and set it as the current tower
        _currentTower = Instantiate(towerPrefab);
        _isPlacing = true;
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return; 
        // If we are placing a tower, move it with the mouse every frame
        if (_isPlacing && _currentTower != null)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _currentTower.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);

            if (Input.GetMouseButtonDown(0))
            {
                _isPlacing = false;
                _currentTower.GetComponent<TowerShooter>()?.Initialize();
                _currentTower = null;
            }
        }
    }
}