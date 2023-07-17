using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �A�C�e���p�̃x�[�X�N���X
/// </summary>
public abstract class ItemBase : MonoBehaviour
{
    [SerializeField] AudioClip _sound;
    public float _destroyTime;

    private void Update()
    {
        Destroy(gameObject, _destroyTime);
    }

    public abstract void Item();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Item();
            Destroy(this.gameObject);
            if (_sound != null)
            {
                AudioSource.PlayClipAtPoint(_sound, Camera.main.transform.position);
            }
        }
    }
}
