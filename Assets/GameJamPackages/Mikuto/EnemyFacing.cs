using UnityEngine;

/// <summary>
/// エネミーのスプライトの向きを常にメインカメラと同じにするコンポーネント
/// </summary>
public class EnemyFacing : MonoBehaviour
{
    Transform _cameraTransform;
    private void Start()
    {
        _cameraTransform = Camera.main.transform;
    }
    void Update()
    {
        transform.rotation = _cameraTransform.rotation;
    }
}
