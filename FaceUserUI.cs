using UnityEngine;

public class FaceUserUI : MonoBehaviour
{

    [SerializeField, Range(0.1f, 8f)] private float _rotationSpeed = 4f;
    private Transform _head;
    private bool _lookAtUser;
    private Quaternion _lastRotation;

    private bool _started = false;

    void Start()
    {
        _head = Camera.main.transform;
    }
    
    void LateUpdate()
    {
        if (_lookAtUser)
            LookAtUser();
    }
    private void LookAtUser()
    {
        Vector3 direction = transform.position - _head.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        
        transform.rotation = Quaternion.Slerp(
            transform.rotation, 
            lookRotation, 
            Time.deltaTime * _rotationSpeed);
        
        _lastRotation = lookRotation;
    }
    
    public void isLookingAtUser(bool x)
    {
        _lookAtUser = x;
        if (x == false)
            transform.rotation = _lastRotation;
    }
}
