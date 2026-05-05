using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(OutlineFeedback))]
public class HandDetection : MonoBehaviour
{
    [Header("Hands")]
    [SerializeField] private HandGrabInteractor _handGrabInteractorLeft;
    [SerializeField] private HandGrabInteractor _handGrabInteractorRight;

    [SerializeField] private RayInteractor _rayInteractorLeft;
    [SerializeField] private RayInteractor _rayInteractorRight;
    
    private OutlineFeedback _outlineFeedback;
    
    [Header("Pinch Setting")]
    [SerializeField] private float _pinchThreshold = 0.7f;
    
    private bool _leftIsPinching = false;
    public bool LeftIsPinching => _leftIsPinching;
    
    private bool _rightIsPinching = false;
    public bool RightIsPinching => _rightIsPinching;
    
    void Start()
    {
        _outlineFeedback = GetComponent<OutlineFeedback>();
    }
    
    void Update()
    {
        
        if (CheckRayPinch(_rayInteractorLeft) || _handGrabInteractorLeft.IsGrabbing)
        {
            _leftIsPinching = true;
            _outlineFeedback.ChangeToSelectColor();
        }
        else
        {
            _leftIsPinching = false;
            _outlineFeedback.ChangeToDefaultColor();
        }

        if (CheckRayPinch(_rayInteractorRight) || _handGrabInteractorRight.IsGrabbing)
        {
            _rightIsPinching = true;
            _outlineFeedback.ChangeToSelectColor();
        }
        else
        {
            _rightIsPinching = false;
            _outlineFeedback.ChangeToDefaultColor();
        }
        
    }
    
    bool CheckRayPinch(RayInteractor rayInteractor)
    {
        if (rayInteractor == null) return false;
        
        RayInteractable selected = rayInteractor.SelectedInteractable;
        
        if (selected != null) return true;

        return false;
    }
    
    
}
