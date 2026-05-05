using Oculus.Interaction;
using UnityEngine;

public class SmoothGrab : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Transform _target;
    
    [Header("Position Settings")]
    [SerializeField] private bool _position = true;
    [SerializeField, Range(0.1f,1f)] private float _positionSmooth = 0.1f;
    
    [Header("Rotation Settings")]
    [SerializeField] private bool _rotation = true;
    [SerializeField, Range(0.1f,1f)] private float _rotationSmooth = 0.1f;

    private Vector3 _currentPos;
    private Quaternion _currentRot;

    private Vector3 _previousPos;
    private Quaternion _previousRot;
    
    private bool _isSmooth;
    
    void Start()
    {
        if (_position)
        {
            _currentPos = _target.position;
            _previousPos = _target.position;
        }
        if (_rotation)
        {
            _currentRot = _target.rotation;
            _previousRot = _target.rotation;
        }
    }

    void LateUpdate()
    {
        if (_isSmooth)
            SmoothTransform();
        else
        {
            if (_position) _target.position = _previousPos;
            if (_rotation) _target.rotation = _previousRot;
        }
    }

    private void SmoothTransform()
    {
        if (_position)
        {
            _currentPos = Vector3.Lerp(_currentPos, _target.position, _positionSmooth);
            _target.position = _currentPos;
            _previousPos = _currentPos;
        }
        if (_rotation)
        {
            _currentRot = Quaternion.Slerp(_currentRot, _target.rotation, _rotationSmooth);
            _target.rotation = _currentRot;
            _previousRot = _currentRot;
        }
        
    }
    public void isSmoothGrab(bool x)
    {
        _isSmooth = x;
    }
}
