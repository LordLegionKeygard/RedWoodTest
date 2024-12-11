using UnityEngine;
using UnityEngine.UI;

public class BaseSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private RectTransform _sliderTransform;
    private Camera _mainCamera;
    private float _heightOffset;
    private Transform _objectTransform;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void SetValue(float value)
    {
        _slider.value = value;
    }


    public void SetHeightOffset(float value)
    {
        _heightOffset = value;
    }

    public void SetupHealth(float maxValue)
    {
        _slider.maxValue = maxValue;
        _slider.value = maxValue;
    }

    public void SetObjectTransform(Transform transform) => _objectTransform = transform;

    private void LateUpdate()
    {
        if(_objectTransform == null) return;

        Vector3 screenPosition = _mainCamera.WorldToScreenPoint(_objectTransform.position + Vector3.up * _heightOffset);
        _sliderTransform.position = screenPosition;
    }
}
