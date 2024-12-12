using UnityEngine;

public class ScrollingEffect : MonoBehaviour
{
    [SerializeField] private float _yOfsset;
    public float _backgroundSize;
    private Transform _cameraTransform;
    private Transform[] layers;
    private float _viewZone = 30;
    private int _leftIndex;
    private int _rightIndex;


    private void Start()
    {
        _cameraTransform = Camera.main.transform;
        layers = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        _leftIndex = 0;
        _rightIndex = layers.Length - 1;
    }


    private void Update()
    {
        if (_cameraTransform.position.x < (layers[_leftIndex].transform.position.x + _viewZone))
        {
            ScrollLeft();
        }

        if (_cameraTransform.position.x > (layers[_rightIndex].transform.position.x - _viewZone))
        {
            ScrollRight();
        }
    }

    private void ScrollLeft()
    {
        float newX = layers[_leftIndex].position.x - _backgroundSize;

        layers[_rightIndex].position = new Vector3(newX, _yOfsset, 0);

        _leftIndex = _rightIndex;
        _rightIndex--;

        if (_rightIndex < 0)
        {
            _rightIndex = layers.Length - 1;
        }
    }

    private void ScrollRight()
    {
        float newX = layers[_rightIndex].position.x + _backgroundSize;

        layers[_leftIndex].position = new Vector3(newX, _yOfsset, 0);

        _rightIndex = _leftIndex;
        _leftIndex++;

        if (_leftIndex == layers.Length)
        {
            _leftIndex = 0;
        }
    }
}