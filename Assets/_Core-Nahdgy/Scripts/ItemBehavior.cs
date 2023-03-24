using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    [SerializeField]
    private innventory _inventory;
    [SerializeField]
    private Animator _objAnimation;
    [SerializeField]
    private string _animName;
    [SerializeField]
    private float _destroyTiming;

    public void DoPickUp(Item _itemBehavior)
    {
        if (_inventory.IsFull())
        {
            return;
        }    
        _inventory.AddItem(_itemBehavior._itemData);
        _objAnimation.PlayInFixedTime(_animName);
        Destroy(_itemBehavior.gameObject, _destroyTiming);

        
    }
}
