using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    public Transform _player;
    public Transform _playerCam;
    public float _throwForce = 10;
  

    [SerializeField] 
    private bool _hasPlayer = false, _beingCarried = false, _touched = false;



    private void Update()
    {
       float _dist = Vector2.Distance(gameObject.transform.position, _player.position); 

        if(_dist <= 1.9f)
        {
            _hasPlayer = true;
        }
        else
        {
            _hasPlayer = false;
        }

        if(_hasPlayer == true && Input.GetButtonDown("Hold"))
        {

            GetComponent<Rigidbody>().isKinematic = true; 
            transform.parent = _playerCam;
            _beingCarried = true;
        }

        if(_beingCarried)
        {
            if(_touched) 
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                _beingCarried = false;  
                _touched= false;
            }

            if(Input.GetButton("Shoot"))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                _beingCarried = false;
                GetComponent<Rigidbody>().AddForce(_playerCam.forward * _throwForce);
            }

            else if(Input.GetButtonUp("Hold"))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                _beingCarried = false;
            }
        }
    }

    private void OnTriggerEnter()
    {
        if(_beingCarried)
        {
            _touched = true;
        }
        
    }
}
