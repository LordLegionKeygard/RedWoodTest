using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _parallaxFactor;
    private Vector3 previousCameraPosition;
    

    private void Start()
    {
        previousCameraPosition = _cameraTransform.position;
    }

    private void Update()
    {
        Vector3 cameraDelta = _cameraTransform.position - previousCameraPosition;
        transform.position += new Vector3(cameraDelta.x * _parallaxFactor, cameraDelta.y * _parallaxFactor, 0);
        previousCameraPosition = _cameraTransform.position;
    }
}
