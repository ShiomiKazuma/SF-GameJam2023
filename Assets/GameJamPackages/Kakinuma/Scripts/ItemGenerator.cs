using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ItemGenerator : MonoBehaviour //ItemBase
{
    [Tooltip("��������A�C�e���̃v���n�u")]
    [SerializeField] GameObject[] _itemPrefab = null;
    [Tooltip("�A�C�e���̐������ƂȂ�G�̃I�u�W�F�N�g")]
    [SerializeField] GameObject _enemy;
    //E_HealthTest e_HealthTest;
    E_Health _enemyHealth; //�{�Ԃ͂��������g�p
    [Tooltip("�A�C�e���̐����K�`��(1�`100)")]
    int _itemProbability = default; //����l0
    [Tooltip("�A�C�e���̐����m��")]
    public int _generationProbability = 50;

    bool _enemyDestroy = true;
    // Start is called before the first frame update
    void Start()
    {
        //_enemyHealth = _enemy.GetComponent<E_Health>(); //�{�Ԃ͂��������g�p
        _enemyHealth = _enemy.GetComponent<E_Health>();
    }

    // Update is called once per frame
    void Update()
    {
        //ItemGen();
        if (_enemyHealth._health <= 0 && _enemyDestroy)
        {
            _enemyDestroy = false;
            _itemProbability = Random.Range(1, 101); //int�^�Ȃ̂ōő�l101�͊܂܂Ȃ�
            Debug.Log(_itemProbability);
            if (_itemProbability <= _generationProbability) //&& _itemProbability != 0)
            {
                var _number = Random.Range(0, _itemPrefab.Length);
                Instantiate(_itemPrefab[_number], this.transform.position, _itemPrefab[_number].transform.rotation); //���[�e�[�V�����ς���\������
            }
        }
    }

    /*void ItemGen()
    {
        for (int i = 0; i < 1; i++)
        {
            if (e_HealthTest._health <= 0)
            {
                _itemProbability = Random.Range(1, 101); //int�^�Ȃ̂ōő�l101�͊܂܂Ȃ�
                Debug.Log("_itemProbability");
            }

            if (_itemProbability <= _generationProbability && _itemProbability != 0)
            {
                var _number = Random.Range(0, _itemPrefab.Length);
                Instantiate(_itemPrefab[_number], this.transform.position, _itemPrefab[_number].transform.rotation); //���[�e�[�V�����ς���\������
            }
        }
    }*/

    /*public override void Item()
    {
        /*if (_enemyHealth.health == 0) //�{�Ԃ͂��������g�p
        {
            _itemProbability = Random.Range(1, 101); //int�^�Ȃ̂ōő�l101�͊܂܂Ȃ�
        }

    }*/
}
