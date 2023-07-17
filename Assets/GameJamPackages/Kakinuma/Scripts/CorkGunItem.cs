using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorkGunItem : ItemBase
{
    PlayerMuzzle.PlayerCondition _playerConditionCork;
    // Start is called before the first frame update

    public override void Item()
    {
        _playerConditionCork = PlayerMuzzle.PlayerCondition.CorkGun;
    }
}
