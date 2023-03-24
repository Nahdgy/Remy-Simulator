using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class innventory : MonoBehaviour
{
    [SerializeField]
    private List<ItemData> _content = new List<ItemData>();
    [SerializeField]
    private Transform _inventorySlotsParents;

    const int InventorySize = 4;



    public void AddItem(ItemData item)
    {
        _content.Add(item);
        AddContentIninventory();
    }
    private void AddContentIninventory()
    {
        for (int i = 0; i < _content.Count; i++)
        {
            _inventorySlotsParents.GetChild(i).GetChild(0).GetComponent<Image>().sprite = _content[i]._visual;

        }
    }
    public bool IsFull()
    {
        return InventorySize == _content.Count;
    }

    public void CheckList()
    {
        for (int i = 0; i < _content[i]; i++)
        {

        }     
    }

}
