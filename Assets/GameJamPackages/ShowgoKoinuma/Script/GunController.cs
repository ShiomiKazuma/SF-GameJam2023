using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] GameObject _bullet;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(_bullet, transform.position, transform.rotation);
        }
    }
}
