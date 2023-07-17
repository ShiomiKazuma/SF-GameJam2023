using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [Tooltip("生成するアイテムのプレハブ")]
    [SerializeField] GameObject[] _itemPrefab = null;
    [Tooltip("アイテムの生成元となる敵のオブジェクト")]
    [SerializeField] GameObject _enemy;
    E_Health _enemyHealth;
    [Tooltip("アイテムの生成ガチャ(1～100)")]
    int _itemProbability = default; //既定値0
    [Tooltip("アイテムの生成確率")]
    public int _generationProbability = 50;

    bool _enemyDestroy = true;
    // Start is called before the first frame update
    void Start()
    {
        _enemyHealth = _enemy.GetComponent<E_Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyHealth._health <= 0 && _enemyDestroy)
        {
            _enemyDestroy = false;
            _itemProbability = Random.Range(1, 101); //int型なので最大値101は含まない
            Debug.Log(_itemProbability);
            if (_itemProbability <= _generationProbability)
            {
                var _number = Random.Range(0, _itemPrefab.Length);
                Instantiate(_itemPrefab[_number], this.transform.position, _itemPrefab[_number].transform.rotation); //ローテーション変える可能性あり
            }
        }
    }
}
