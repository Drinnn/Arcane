using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour {
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    private float _ortographicSize;
    private float _targetOrtographicSize;

    private void Start() {
        _ortographicSize = cinemachineVirtualCamera.m_Lens.OrthographicSize;
        _targetOrtographicSize = _ortographicSize;
    }

    private void Update() {
        HandleMovement();
        HandleZoom();
    }

    private void HandleMovement() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(x, y).normalized;
        float moveSpeed = 30f;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    private void HandleZoom() {
        float zoomAmount = 2f;
        _targetOrtographicSize -= Input.mouseScrollDelta.y * zoomAmount;

        float minOrtographicSize = 10;
        float maxOrtographicSize = 30;
        _targetOrtographicSize = Mathf.Clamp(_targetOrtographicSize, minOrtographicSize, maxOrtographicSize);

        float zoomSpeed = 5f;
        _ortographicSize = Mathf.Lerp(_ortographicSize, _targetOrtographicSize, Time.deltaTime * zoomSpeed);

        cinemachineVirtualCamera.m_Lens.OrthographicSize = _ortographicSize;
    }
}

