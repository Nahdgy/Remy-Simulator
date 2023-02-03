using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/New Item")]
public class ItemData : ScriptableObject
{

    public string _name;
    public Sprite _visual;
    public GameObject _prefab;

}
