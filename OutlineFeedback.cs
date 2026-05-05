using System;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using Oculus.Interaction.Input;

[RequireComponent(typeof(HandDetection))]
public class OutlineFeedback : MonoBehaviour
{
    [Header("References")]
    [SerializeField] 
    private MaterialPropertyBlockEditor _leftHandMaterialPropertyBlock;
    [SerializeField] 
    private MaterialPropertyBlockEditor _rightHandMaterialPropertyBlock;
    
    private HandDetection _handDetection;
    
    [Header("Outline Colors")]
    [SerializeField] private Color _defaultColor;
    //[SerializeField] private Color _hoverColor;
    [SerializeField] private Color _selectColor;
    
    [Header("Outline Width")]
    [SerializeField] private float _outlineWidth;

    private MaterialPropertyColor _leftHandOutlineColor;
    private MaterialPropertyColor _rightHandOutlineColor;
    
    private void Start()
    {
        if (_leftHandMaterialPropertyBlock == null || _rightHandMaterialPropertyBlock == null)
            Debug.LogWarning("The left or right hand material property is not set");

        _leftHandOutlineColor =  _leftHandMaterialPropertyBlock.ColorProperties[0];
        _rightHandOutlineColor = _rightHandMaterialPropertyBlock.ColorProperties[0];
        
        _handDetection = GetComponent<HandDetection>();
        
    }
    
    public void ChangeToDefaultColor()
    {
        if (!_handDetection.LeftIsPinching)
        {
            _leftHandOutlineColor.value = _defaultColor;
            _leftHandMaterialPropertyBlock.ColorProperties[0] = _leftHandOutlineColor;
        }
        
        if (!_handDetection.RightIsPinching)
        {
            _rightHandOutlineColor.value = _defaultColor;
            _rightHandMaterialPropertyBlock.ColorProperties[0] = _rightHandOutlineColor;
        }
    }
    /*
    public void ChangeToHoverColor()
    {
        if (_handDetection.LeftIsPinching)
        {
            _leftHandOutlineColor.value = _hoverColor;
            _leftHandMaterialPropertyBlock.ColorProperties[0] = _leftHandOutlineColor;
        }
        if (_handDetection.RightIsPinching)
        {
            _rightHandOutlineColor.value = _hoverColor;
            _rightHandMaterialPropertyBlock.ColorProperties[0] = _rightHandOutlineColor;
        }
    }
    */
    
    public void ChangeToSelectColor()
    {
        if (_handDetection.LeftIsPinching)
        {
            _leftHandOutlineColor.value = _selectColor;
            _leftHandMaterialPropertyBlock.ColorProperties[0] = _leftHandOutlineColor;
        }
        if (_handDetection.RightIsPinching)
        {
            _rightHandOutlineColor.value = _selectColor;
            _rightHandMaterialPropertyBlock.ColorProperties[0] = _rightHandOutlineColor;
        }
        
    }
}
