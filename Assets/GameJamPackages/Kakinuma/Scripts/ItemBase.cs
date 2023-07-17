using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテム用のベースクラス
/// </summary>
public abstract class ItemBase : MonoBehaviour
{
    [SerializeField] AudioClip _sound;

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
