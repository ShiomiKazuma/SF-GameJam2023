using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMuzzle : MonoBehaviour
{
    [SerializeField, Header("銃口の位置")] GameObject _muzzle;
    /// <summary>真ん中の銃口 </summary>
    Transform _muzzlePos;
    /// <summary> プレイヤーの状態</summary>
    public PlayerCondition _playerCondition;
    /// <summary> 水鉄砲の発射間隔</summary>
    [SerializeField, Header ( "水鉄砲の発射間隔")] float _waterGunInterval;
    /// <summary>水鉄砲の見た目</summary>
    [SerializeField, Header("水鉄砲の見た目")] Material _waterGunMaterial;
    [SerializeField, Header("水鉄砲の弾")] GameObject _waterBullet = default;
    Material _playerMaterial;
    /// <summary> コルク銃の発射間隔</summary>
    [SerializeField, Header("コルク銃の発射間隔")] float _corkGunInterval;
    /// <summary>コルク銃の見た目</summary>
    [SerializeField, Header("コルク銃の見た目")] Material _corkGunMaterial;
    [SerializeField, Header("コルク銃の弾")] GameObject _corkBullet = default;
    float _bulletTimer = 0;
    int _changeCount = 0;
    /// <summary>通常時の水鉄砲の弾速</summary>
    [SerializeField, Header("通常時の水鉄砲の弾速")] float _waterBulletSpeed;
    /// <summary>通常時の水鉄砲の威力</summary>
    [SerializeField, Header("通常時の水鉄砲の威力")] float _waterBulletPower;
    /// <summary>パワーアップ時水鉄砲の弾速 </summary>
    //[SerializeField, Header("パワーアップ時水鉄砲の弾速")] float _waterBulletPowerUpSpeed;
    /// <summary>パワーアップ時水鉄砲の威力 </summary>
    //[SerializeField, Header("パワーアップ時水鉄砲の威力")] float _waterBulletPowerUpPower;
    /// <summary>通常時のコルク銃の弾速</summary>
    [SerializeField, Header("通常時のコルク銃の弾速")] float _corkGunBulletSpeed;
    /// <summary>通常時のコルク銃の威力</summary>
    [SerializeField, Header("通常時のコルク銃の威力")] float _corkGunBulletPower;
    /// <summary>パワーアップ時コルク銃の弾速 </summary>
    //[SerializeField, Header("パワーアップ時コルク銃の弾速")] float _corkGunBulletPowerUpSpeed;
    /// <summary>パワーアップ時コルク銃の威力 </summary>
    //[SerializeField, Header("パワーアップ時コルク銃の威力")] float _corkGunBulletPowerUpPower;
    public float _currentBulletSpeed { get; set; }
    public float _currentBulletPower { get; set; }
    /// <summary>弾速のパワーアップ時間</summary>
    float _bulletSpeedUpRoutine;
    /// <summary>弾速のパワーアップフラグ</summary>
    bool _bulletSpeedUp = false;
    /// <summary>威力のパワーアップ時間</summary>
    float _bulletPowerUpRoutine;
    /// <summary>威力のパワーアップフラグ</summary>
    bool _bulletPowerUp = false;

    float _bulletSpeedTimer;
    float _bulletPowerTimer;

    // Start is called before the first frame update
    void Start()
    {
        //マズルの位置を取得
        _muzzlePos = _muzzle.transform;
        //プレイヤーの初期状態
        _playerCondition = PlayerCondition.WaterGun;
        //プレイヤーの見た目の初期化
        _playerMaterial = _waterGunMaterial;
        _bulletTimer = _waterGunInterval;
        //銃のステータスの初期化
        _currentBulletSpeed = _waterBulletSpeed;
        _currentBulletPower = _waterBulletPower;
    }

    // Update is called once per frame
    void Update()
    {
        _bulletTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && _playerCondition == PlayerCondition.WaterGun && _bulletTimer  > _waterGunInterval)
        {
            Instantiate(_waterBullet, _muzzlePos.position, Quaternion.identity);
            _bulletTimer = 0;
        }

        if(Input.GetMouseButtonDown(0) && _playerCondition == PlayerCondition.CorkGun && _bulletTimer > _corkGunInterval)
        {
            if(_changeCount == 0)
            {
                _playerMaterial = _corkGunMaterial;
                _changeCount = 1;
            }
            //真ん中の銃口
            Instantiate(_corkBullet, _muzzlePos.position, Quaternion.identity);
            _bulletTimer = 0;
        }
    }

    void PowerUpBulletSpeed(float powerUp, float routine)
    {
        _bulletSpeedUp = true;
        _bulletSpeedTimer = 0;
        _bulletSpeedUpRoutine = routine;
        float _saveBulletSpeed = _currentBulletSpeed;
        _currentBulletSpeed = _currentBulletSpeed * powerUp;
    }

    void PowerUpBulletPower(float powerUp, float routine)
    {
        _bulletPowerUp = true;
        _bulletTimer = 0;
        _bulletSpeedTimer = routine;
        float _saveBulletSpeed = _currentBulletSpeed;
        _currentBulletSpeed = _currentBulletSpeed * powerUp;
    }

    

    //public IEnumerator PowerUpGunBullet(float powerUp, float routine)
    //{
    //    float _saveBulletSpeed = _currentBulletSpeed;
    //    _currentBulletSpeed = _currentBulletSpeed * powerUp;

    //    yield return new WaitForSeconds(routine);
    //    if(_currentBulletSpeed == _saveBulletSpeed * powerUp)
    //    {
    //        _currentBulletSpeed = _saveBulletSpeed;
    //    }

    //}

    //public IEnumerator PowerUpGunPower(float powerUp, float routine)
    //{
    //    float _saveBulletPower = _currentBulletPower;
    //    _currentBulletPower = _currentBulletPower * powerUp;

    //    yield return new WaitForSeconds(routine);
    //    if (_currentBulletPower == _saveBulletPower * powerUp)
    //    {
    //        _currentBulletPower = _saveBulletPower;
    //    }

}



    public enum PlayerCondition
    {
        WaterGun,
        CorkGun,
    }
}
