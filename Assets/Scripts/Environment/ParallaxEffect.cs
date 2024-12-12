using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float _paralaxSpeed;
    private Transform _cameraTransform;
    private float _lastCameraX;


    private void Start()
    {
        _cameraTransform = Camera.main.transform;
        _lastCameraX = _cameraTransform.position.x;
    }


    private void Update()
    {
        float deltaX = _cameraTransform.position.x - _lastCameraX;
        transform.position += Vector3.right * (deltaX * _paralaxSpeed);

        _lastCameraX = _cameraTransform.position.x;
    }
}