using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemyController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed, _runSpeed, _jumpForce, _playerHeight,_speedDrag,_moveMultiplier,_climbSpeed,_dashDuration, _initialSpeed;
    private float _horizontalInput,_jumpCooldown,_verticalInput, _jumpInput ;
 
    [SerializeField]
    private bool _isGrounded,_canJump, _canClimb;

    [SerializeField]
    private int _ladder = 7;
   
    [SerializeField]
    private LayerMask _whatIsGround;
    [SerializeField]
    private Vector3 _moveDirection, _velocity = Vector3.zero;
   

    [SerializeField]
    private Rigidbody _rb;
    [SerializeField]
    private Transform _oriantation, _player;
    [SerializeField]
    private GameObject _climbUI;
    

   

    private void Start()
    {
       _rb = GetComponent<Rigidbody>();
       _rb.freezeRotation = true;
       _initialSpeed = _moveSpeed;


    }

    private void FixedUpdate()
    {
        Move();
    }
    void ControllerInputs()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        
        if (Input.GetButtonDown("Jump") && _canJump && _isGrounded )
        {
          _canJump = false;
           Jump();
           Invoke(nameof(JumpYouCan), _jumpCooldown);
           
        }
    } 
    private void Dash()
    {
        if(Input.GetButton("Boost"))
        {
            Debug.Log("run");
            StartCoroutine(BoostTimer());       
        }
    }
    private IEnumerator BoostTimer()
    {
       _moveSpeed = _runSpeed; 
        yield return new WaitForSeconds(_dashDuration);
        Debug.Log("retour");
        _moveSpeed = _initialSpeed;
        yield return new WaitForSeconds(_dashDuration);
    }
    void GroundCheck()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight * .5f + .2f, _whatIsGround);
    }
    void Jump()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
        _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }
    void JumpYouCan()
    {
        _canJump = true;
    }
    void Move()
    {
        _moveDirection = _oriantation.forward * _verticalInput + _oriantation.right * _horizontalInput;
        if (_isGrounded) _rb.AddForce(_moveDirection.normalized * _moveSpeed, ForceMode.Force);
        else if (!_isGrounded) _rb.AddForce(_moveDirection.normalized * _moveSpeed * _moveMultiplier, ForceMode.Force);
    }

    void SetDrag()
    {
      if(_isGrounded) 
      {
      _rb.drag = _speedDrag;     
      } 
      else _rb.drag = 0;  
    }

    void LimitVelocity()
    {
        Vector3 _vel = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
        if (_vel.magnitude > _moveSpeed)
        {
            Vector3 _limitVel = _vel.normalized * _moveSpeed;
            _rb.velocity = new Vector3(_limitVel.x, _rb.velocity.y, _limitVel.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == _ladder)
        {
            _climbUI.SetActive(true);
            _canClimb = true;
        }      
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == _ladder)
        {
            _climbUI.SetActive(false);
            _canClimb = false;
        }


    }

    private void Climb(float _climbMovement)
    {
        if(Input.GetButton("Climb") && _canClimb == true)
        {
            
            _moveDirection = _player.up * _climbSpeed;
            _rb.AddForce(_moveDirection.normalized * _climbSpeed, ForceMode.Force);
        }

    }

   

    private void Update()
    {
        ControllerInputs();
        GroundCheck();
        LimitVelocity();
        SetDrag();
        float _climbMovement = Input.GetAxis("Vertical") * _moveSpeed;
        Climb( _climbMovement );
        Dash();
    }

}
