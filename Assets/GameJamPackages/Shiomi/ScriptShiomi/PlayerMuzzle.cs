using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMuzzle : MonoBehaviour
{
    [SerializeField, Header("�e���̈ʒu")] GameObject _muzzle;
    /// <summary>�^�񒆂̏e�� </summary>
    Transform _muzzlePos;
    /// <summary> �v���C���[�̏��</summary>
    public PlayerCondition _playerCondition;
    /// <summary> ���S�C�̔��ˊԊu</summary>
    [SerializeField, Header ( "���S�C�̔��ˊԊu")] float _waterGunInterval;
    /// <summary>���S�C�̌�����</summary>
    [SerializeField, Header("���S�C�̌�����")] Material _waterGunMaterial;
    [SerializeField, Header("���S�C�̒e")] GameObject _waterBullet = default;
    Material _playerMaterial;
    /// <summary> �R���N�e�̔��ˊԊu</summary>
    [SerializeField, Header("�R���N�e�̔��ˊԊu")] float _corkGunInterval;
    /// <summary>�R���N�e�̌�����</summary>
    [SerializeField, Header("�R���N�e�̌�����")] Material _corkGunMaterial;
    [SerializeField, Header("�R���N�e�̒e")] GameObject _corkBullet = default;
    float _bulletTimer = 0;
    int _changeCount = 0;
    /// <summary>�ʏ펞�̐��S�C�̒e��</summary>
    [SerializeField, Header("�ʏ펞�̐��S�C�̒e��")] float _waterBulletSpeed;
    /// <summary>�ʏ펞�̐��S�C�̈З�</summary>
    [SerializeField, Header("�ʏ펞�̐��S�C�̈З�")] float _waterBulletPower;
    /// <summary>�p���[�A�b�v�����S�C�̒e�� </summary>
    //[SerializeField, Header("�p���[�A�b�v�����S�C�̒e��")] float _waterBulletPowerUpSpeed;
    /// <summary>�p���[�A�b�v�����S�C�̈З� </summary>
    //[SerializeField, Header("�p���[�A�b�v�����S�C�̈З�")] float _waterBulletPowerUpPower;
    /// <summary>�ʏ펞�̃R���N�e�̒e��</summary>
    [SerializeField, Header("�ʏ펞�̃R���N�e�̒e��")] float _corkGunBulletSpeed;
    /// <summary>�ʏ펞�̃R���N�e�̈З�</summary>
    [SerializeField, Header("�ʏ펞�̃R���N�e�̈З�")] float _corkGunBulletPower;
    /// <summary>�p���[�A�b�v���R���N�e�̒e�� </summary>
    //[SerializeField, Header("�p���[�A�b�v���R���N�e�̒e��")] float _corkGunBulletPowerUpSpeed;
    /// <summary>�p���[�A�b�v���R���N�e�̈З� </summary>
    //[SerializeField, Header("�p���[�A�b�v���R���N�e�̈З�")] float _corkGunBulletPowerUpPower;
    public float _currentBulletSpeed { get; set; }
    public float _currentBulletPower { get; set; }
    /// <summary>�e���̃p���[�A�b�v����</summary>
    float _bulletSpeedUpRoutine;
    /// <summary>�e���̃p���[�A�b�v�t���O</summary>
    bool _bulletSpeedUp = false;
    /// <summary>�З͂̃p���[�A�b�v����</summary>
    float _bulletPowerUpRoutine;
    /// <summary>�З͂̃p���[�A�b�v�t���O</summary>
    bool _bulletPowerUp = false;

    float _bulletSpeedTimer;
    float _bulletPowerTimer;

    PlayerCondition _savePlayerCondition;

    // Start is called before the first frame update
    void Start()
    {
        //�}�Y���̈ʒu���擾
        _muzzlePos = _muzzle.transform;
        //�v���C���[�̏������
        _playerCondition = PlayerCondition.WaterGun;
        //�v���C���[�̌����ڂ̏�����
        _playerMaterial = _waterGunMaterial;
        _bulletTimer = _waterGunInterval;
        //�e�̃X�e�[�^�X�̏�����
        _currentBulletSpeed = _waterBulletSpeed;
        _currentBulletPower = _waterBulletPower;
    }

    // Update is called once per frame
    void Update()
    {
        _bulletTimer += Time.deltaTime;

        if (_bulletSpeedUp)
        {
            _bulletSpeedTimer += Time.deltaTime;
            if(_bulletSpeedTimer >= _bulletSpeedUpRoutine)
            {
                BulletSpeedDefault();
            }
        }

        if (_bulletPowerUp)
        {
            _bulletPowerTimer -= Time.deltaTime;
            if(_bulletPowerTimer >= _bulletPowerUpRoutine) 
            {
                BulletPowerDefault();
            }
        }

        if (Input.GetMouseButtonDown(0) && _playerCondition == PlayerCondition.WaterGun && _bulletTimer  > _waterGunInterval)
        {
            Instantiate(_waterBullet, _muzzlePos.position, Quaternion.identity);
            _bulletTimer = 0;
        }

        if(Input.GetMouseButtonDown(0) && _playerCondition == PlayerCondition.CorkGun && _bulletTimer > _corkGunInterval)
        {
            //�^�񒆂̏e��
            Instantiate(_corkBullet, _muzzlePos.position, Quaternion.identity);
            _bulletTimer = 0;
        }
    }

    //�e���̃p���[�A�b�v
    public void PowerUpBulletSpeed(float powerUp, float routine)
    {
        _savePlayerCondition = _playerCondition;
        _bulletSpeedUp = true;
        _bulletSpeedTimer = 0;
        _bulletSpeedUpRoutine = routine;
        _currentBulletSpeed = _currentBulletSpeed * powerUp;
    }

    //�З͂̃p���[�A�b�v
    public void PowerUpBulletPower(float powerUp, float routine)
    {
        _savePlayerCondition = _playerCondition;
        _bulletPowerUp = true;
        _bulletPowerTimer = 0;
        _bulletPowerUpRoutine = routine;
        _currentBulletPower = _currentBulletPower * powerUp;
    }

    //�e����ʏ�ɖ߂�
    void BulletSpeedDefault()
    {
        if(_savePlayerCondition == _playerCondition)
        {
            if(_playerCondition == PlayerCondition.WaterGun)
            {
                _currentBulletSpeed = _waterBulletSpeed;
            }
            else if(_playerCondition == PlayerCondition.CorkGun)
            {
                _currentBulletSpeed = _corkGunBulletSpeed;
            }
        }

        _bulletSpeedUp = false;
    }

    //�З͂����ɖ߂�
    void BulletPowerDefault()
    {
        if (_savePlayerCondition == _playerCondition)
        {
            if (_playerCondition == PlayerCondition.WaterGun)
            {
                _currentBulletPower = _waterBulletPower;
            }
            else if (_playerCondition == PlayerCondition.CorkGun)
            {
                _currentBulletPower = _corkGunBulletPower;
            }
        }

        _bulletPowerUp = false;
    }

    public void ChangeCorkGun()
    {
        if (_changeCount == 0)
        {
            _playerMaterial = _corkGunMaterial;
            _changeCount = 1;
            _playerCondition = PlayerCondition.CorkGun;
            _currentBulletSpeed = _corkGunBulletSpeed;
            _currentBulletPower = _corkGunBulletPower;
        }
        

    }

    //�З͂����ɖ߂�

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

    public enum PlayerCondition
    {
        WaterGun,
        CorkGun,
    }
}



