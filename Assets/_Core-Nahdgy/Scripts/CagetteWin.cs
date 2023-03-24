using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CagetteWin : MonoBehaviour
{
    public List<GrabObject> legumes = new List<GrabObject>();
    [SerializeField]
    private UI winning;
    [SerializeField] 
    private int obj = 9;


    private void Update()
    {
        GotVegetables();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == obj)
        {
            Destroy(other.gameObject);
        }
    }

    private void GotVegetables()
    {
        legumes = FindObjectsOfType<GrabObject>().ToList();
        if(legumes.Count == 0 ) 
        {
            winning.WinScene();
        }
    }
}
