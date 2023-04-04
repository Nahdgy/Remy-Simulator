using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class ActionZone : MonoBehaviour
{
    [SerializeField]
    private int _player = 6;
    [SerializeField]
    private float _animTime;
    [SerializeField]
    private bool _isInside, _palyerHere;
    [SerializeField]
    private Animator _animationZone;
    [SerializeField]
    private string _animName,_objName;
    [SerializeField]
    private ParticleSystem _particle;
    [SerializeField]
    private GameObject _UI, _goPickUI;
    [SerializeField]
    private Rigidbody _remyRb;

    public innventory _bagChek;
    [SerializeField]
    private ItemData _objData;
    [SerializeField]
    private RemyController _remyController;
    [SerializeField]
    private RemyCamera _remyCamera;



    private void Update()
    {
        InventoryChanges();
        CheckList();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == _player)
        {
            _palyerHere = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == _player)
        {
            _palyerHere = false;
            _particle.startColor = Color.white;
            _goPickUI.SetActive(false);
            _UI.SetActive(false);
        }
    }

    private void InventoryChanges()
    {
        if (_palyerHere && _isInside)
        {
            _particle.startColor = new Color(0, 1, 0.02f, 1f);
            _UI.SetActive(true);

                if(Input.GetButton("Action"))
                {
                    StartCoroutine(Animation());
                    _UI.SetActive(false);   
                    _animationZone.PlayInFixedTime(_animName);
                }
        }

        if(_palyerHere && _isInside == false)
        {
            _particle.startColor = new Color(1, 0, 0, 1f);
            _goPickUI.SetActive(true);
        }
    }
    public void CheckList()
    {
        if (_bagChek._content.Contains(_objData))
        {
            Debug.Log("L'objet est dans l'inventaire");
            _isInside = true;
        }

    }

    private IEnumerator Animation()
    {
        _remyRb.isKinematic = true;
        _remyController._canMove = false;
        _remyCamera._canSee = false;
        yield return new WaitForSeconds(_animTime);
        _remyRb.isKinematic = false;
        _remyController._canMove = true;
        _remyCamera._canSee = true;


    }
}
