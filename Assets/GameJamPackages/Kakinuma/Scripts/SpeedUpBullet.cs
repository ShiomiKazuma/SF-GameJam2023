using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpBullet : ItemBase
{
    PlayerMuzzle _playerMuzzleScript;
    [Tooltip("’e‘¬")]
    public float _upPower;
    [Tooltip("Œø‰ÊŽžŠÔ")]
    public float _routine;
    // Start is called before the first frame update
    void Start()
    {
        _playerMuzzleScript = GetComponent<PlayerMuzzle>();
    }

    // Update is called once per frame
    public override void Item()
    {
        _playerMuzzleScript.PowerUpBulletPower(_upPower, _routine);
    }
}
