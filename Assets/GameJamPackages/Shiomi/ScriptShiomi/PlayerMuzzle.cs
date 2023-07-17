using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMuzzle : MonoBehaviour
{
    [SerializeField, Header("eŒû‚ÌˆÊ’u")] GameObject _muzzle;
    /// <summary>^‚ñ’†‚ÌeŒû </summary>
    Transform _muzzlePos;
    /// <summary> ƒvƒŒƒCƒ„[‚Ìó‘Ô</summary>
    public PlayerCondition _playerCondition;
    /// <summary> …“S–C‚Ì”­ËŠÔŠu</summary>
    [SerializeField, Header ( "…“S–C‚Ì”­ËŠÔŠu")] float _waterGunInterval;
    /// <summary>…“S–C‚ÌŒ©‚½–Ú</summary>
    [SerializeField, Header("…“S–C‚ÌŒ©‚½–Ú")] Material _waterGunMaterial;
    [SerializeField, Header("…“S–C‚Ì’e")] GameObject _waterBullet = default;
    Material _playerMaterial;
    /// <summary> ƒRƒ‹ƒNe‚Ì”­ËŠÔŠu</summary>
    [SerializeField, Header("ƒRƒ‹ƒNe‚Ì”­ËŠÔŠu")] float _corkGunInterval;
    /// <summary>ƒRƒ‹ƒNe‚ÌŒ©‚½–Ú</summary>
    [SerializeField, Header("ƒRƒ‹ƒNe‚ÌŒ©‚½–Ú")] Material _corkGunMaterial;
    [SerializeField, Header("ƒRƒ‹ƒNe‚Ì’e")] GameObject _corkBullet = default;
    float _timer = 0;
    int _changeCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //ƒ}ƒYƒ‹‚ÌˆÊ’u‚ğæ“¾
        _muzzlePos = _muzzle.transform;
        //ƒvƒŒƒCƒ„[‚Ì‰Šúó‘Ô
        _playerCondition = PlayerCondition.WaterGun;
        //ƒvƒŒƒCƒ„[‚ÌŒ©‚½–Ú‚Ì‰Šú‰»
        _playerMaterial = _waterGunMaterial;
        _timer = _waterGunInterval;
    }

    // Update is called once per frame
    void Update()
    {
         _timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && _playerCondition == PlayerCondition.WaterGun && _timer  > _waterGunInterval)
        {
            Instantiate(_waterBullet, _muzzlePos.position, Quaternion.identity);
            _timer = 0;
        }

        if(Input.GetMouseButtonDown(0) && _playerCondition == PlayerCondition.CorkGun && _timer > _corkGunInterval)
        {
            if(_changeCount == 0)
            {
                _playerMaterial = _corkGunMaterial;
                _changeCount = 1;
            }
            //^‚ñ’†‚ÌeŒû
            Instantiate(_corkBullet, _muzzlePos.position, Quaternion.identity);
            _timer = 0;
        }
    }

    public enum PlayerCondition
    {
        WaterGun,
        CorkGun,
    }
}
