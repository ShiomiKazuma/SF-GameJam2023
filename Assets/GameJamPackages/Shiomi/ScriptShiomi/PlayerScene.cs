using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerHp))]
public class PlayerScene : MonoBehaviour
{
    PlayerHp _curentplayerHp;
    // Start is called before the first frame update
    void Start()
    {
        _curentplayerHp = GetComponent<PlayerHp>();
    }

    // Update is called once per frame
    void Update()
    {
        if( _curentplayerHp != null )
        {
            if (_curentplayerHp._curentHp < 0) SceneManager.LoadScene("ResultScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("GameClearZone"))
        {
            if (_curentplayerHp != null)
                SceneManager.LoadScene("ClearScene");
        }
    }
}
