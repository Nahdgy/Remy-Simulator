using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnim : MonoBehaviour
{
    [SerializeField]
    private GameObject oignon;
    [SerializeField]
    private float _timing;
    [SerializeField]
    private Animator _animator;


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        InputPlay();
    }

    private void InputPlay()
    {
        if(Input.GetButton("Action"))
        {
            StartCoroutine(Animation());
        }
    }
    public IEnumerator Animation()
    {
        yield return new WaitForSeconds(_timing);
        _animator.enabled = false;

    }
}
