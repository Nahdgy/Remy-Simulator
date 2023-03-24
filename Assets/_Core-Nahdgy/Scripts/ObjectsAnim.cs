using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsAnim : MonoBehaviour
{
    [SerializeField]
    private Animator _objAnimation;
    [SerializeField]
    private string _animName;
    // Start is called before the first frame update
    public void ObjToPocket()
    {
        _objAnimation.PlayInFixedTime(_animName);
    }
}
