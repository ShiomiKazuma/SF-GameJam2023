using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 回復アイテム用スクリプト
/// </summary>
public class Recovery : ItemBase
{
    GameObject _player;
    PlayerHp _playerHp;
    public float _recveryHp = 20f;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _playerHp = _player.GetComponent<PlayerHp>();
    }

    // Update is called once per frame
    public override void Item()
    {
        //HP回復
        _playerHp._curentHp += _recveryHp;
        //HPが最大値より多ければ最大値にする
        if(_playerHp._curentHp > _playerHp._maxHp)
        {
            _playerHp._curentHp = _playerHp._maxHp;
        }
    }
}
