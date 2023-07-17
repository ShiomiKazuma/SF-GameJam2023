using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpBullet : ItemBase
{
    GameObject _player;
    PlayerMuzzle _playerMuzzleScript;
    [Tooltip("ˆÐ—Í")]
    public float _upPower;
    [Tooltip("Œø‰ÊŽžŠÔ")]
    public float _routine;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _playerMuzzleScript = _player.GetComponent<PlayerMuzzle>();
    }

    // Update is called once per frame

    public override void Item()
    {
        _playerMuzzleScript.PowerUpBulletPower(_upPower, _routine);
    }
}
