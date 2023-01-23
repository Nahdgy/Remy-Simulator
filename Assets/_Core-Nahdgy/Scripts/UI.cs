using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    [SerializeField]
    private int _remy = 6;
    [SerializeField]
    private GameObject _actionUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _remy)
        {
            _actionUI.SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == _remy)
        {
            _actionUI.SetActive(false);

        }
    }
}
