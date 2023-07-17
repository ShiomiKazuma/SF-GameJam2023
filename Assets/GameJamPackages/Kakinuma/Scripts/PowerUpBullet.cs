using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpBullet : ItemBase
{
    PlayerMuzzle _playerMuzzleScript;
    [Tooltip("威力")]
    public float _upPower;
    [Tooltip("効果時間")]
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
