using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBordFire : MonoBehaviour
{
    [SerializeField]
    private Camera _cam;

    private void Update()
    {
        transform.LookAt(_cam.transform);
    }
}
