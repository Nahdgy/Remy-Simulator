using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapin : MonoBehaviour
{
    [SerializeField]
    private Camera _centerCam;
    [SerializeField]
    private RaycastHit _hit;
    [SerializeField]
    private int _maxDistance;
    [SerializeField]
    private bool _isMoving;
    [SerializeField]
    private Vector3 _location;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Transform _hook;

    public RemyController _controller;
    public LineRenderer _lineR;

    
   
    void Update()
    {
        GoGrap();
        Moving();
    }
    private void GoGrap()
    {
        if (Input.GetKey(KeyCode.G))
        { 
            if (Physics.Raycast(_centerCam.transform.position, _centerCam.transform.forward, out _hit, _maxDistance))
            {
                _isMoving = true;
                _location = _hit.point;
                //_controller.CanMove = false;
                //_controller.GravityMultiplier = 1;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                _lineR.enabled = true;
                _lineR.SetPosition(1, _location);
            }
        }
        if (Input.GetKeyUp(KeyCode.G)) 
        {
            _isMoving = false;
            //_controller.CanMove = true;
            _controller._gravityMultiplier = 2;
            _lineR.enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;

        }

    }

    private void Moving()
    {
        if (_isMoving) 
        { 
            transform.position = Vector3.Lerp(_location, _location, _speed * Time.deltaTime / Vector3.Distance(transform.position, _location));
            _lineR.SetPosition(0,_hook.position);
        }
       

        if (Vector3.Distance(transform.position, _location) < 1f)
        {
            _isMoving = false;
            //_controller.CanMove = true;
            _controller._gravityMultiplier = 2;
            _lineR.enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
