using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunItem : ItemBase
{
    PlayerMuzzle.PlayerCondition _playerConditionWater;
    // Start is called before the first frame update

    public override void Item()
    {
        _playerConditionWater = PlayerMuzzle.PlayerCondition.WaterGun;
    }
}
