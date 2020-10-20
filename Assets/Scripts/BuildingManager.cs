using UnityEngine;

public class BuildingManager : MonoBehaviour {

    [SerializeField] private Transform pfWoodHarvester;

    private Camera mainCamera;

    private void Start() {
        mainCamera = Camera.main;
    }
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(pfWoodHarvester, GetMouseWorldPosition(), Quaternion.identity);
        }
    }

    private Vector3 GetMouseWorldPosition() {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        return mousePosition;
    }
}
