using UnityEngine;

/// <summary>
/// �G�l�~�[�̃X�v���C�g�̌�������Ƀ��C���J�����Ɠ����ɂ���R���|�[�l���g
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
