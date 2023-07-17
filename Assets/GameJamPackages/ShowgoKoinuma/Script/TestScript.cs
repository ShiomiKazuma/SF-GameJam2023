using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] PlayerMuzzle _playerMuzzle;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            _playerMuzzle.ChangeCorkGun();
        }
    }
}
