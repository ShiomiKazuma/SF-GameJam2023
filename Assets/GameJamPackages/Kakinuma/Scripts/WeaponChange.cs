using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : ItemBase
{
    PlayerMuzzle _playerMuzzleScript;
    // Start is called before the first frame update
    void Start()
    {
        _playerMuzzleScript = GetComponent<PlayerMuzzle>();
    }

    // Update is called once per frame

    public override void Item()
    {
        _playerMuzzleScript.ChangeCorkGun();
    }
}
