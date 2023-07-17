using UnityEngine;
using UnityEngine.UI;


public class MoveCompas : MonoBehaviour
{
    [SerializeField] Image _image;                  //コンパスのイメージ
    [SerializeField] Transform _player;             //プレイヤーの位置など取得
    [SerializeField] float _angleOffset = 0f;       //アングルの初期化

    RectTransform rt;                               //UI用のTransform
    Quaternion q;                                   //コンパスの回転
    Quaternion offset;                              //回転のオフセット


    // Start is called before the first frame update
    void Start()
    {
        rt = _image.rectTransform;                                      //コンパスの位置（Transform）
        offset = Quaternion.AngleAxis(_angleOffset, Vector3.up);        //playerのｙ軸を中心に回転する

    }

    // Update is called once per frame
    void Update()
    {
        q = _player.rotation * offset;                                  //playerの回転を取得
        q.z = q.y;
        q.y = 0f;

        rt.rotation = q;                                                //コンパスのｚ軸をplayerのｙ軸で回転させる
    }
}
