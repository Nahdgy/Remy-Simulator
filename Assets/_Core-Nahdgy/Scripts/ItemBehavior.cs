using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    [SerializeField]
    private innventory _inventory;
    [SerializeField]
    private float _destroyTiming;
    [SerializeField]
    public ObjectsAnim _animObj;

    public void DoPickUp(Item _itemBehavior)
    {
        if (_inventory.IsFull())
        {
            return;
        }    
        _inventory.AddItem(_itemBehavior._itemData);
        _animObj.ObjToPocket();
        Destroy(_itemBehavior.gameObject, _destroyTiming);

        
    }
}
