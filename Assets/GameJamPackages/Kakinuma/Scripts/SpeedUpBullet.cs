using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpBullet : ItemBase
{
    GameObject _player;
    PlayerMuzzle _playerMuzzleScript;
    [Tooltip("弾速")]
    public float _upSpeed;
    [Tooltip("効果時間")]
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
        _playerMuzzleScript.PowerUpBulletSpeed(_upSpeed, _routine);
    }
}
