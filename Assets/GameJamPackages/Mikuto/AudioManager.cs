using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [Header("SE�p�I�[�f�B�I�\�[�X")] public AudioSource _se;
    [Header("BGM�p�I�[�f�B�I�\�[�X")] public AudioSource _bgm;
    [Header("SE�p����"), SerializeField] AudioClip[] _seClip;
    [Header("BGM�p����"), SerializeField] AudioClip[] _bgmClip;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += SceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// �V�[���ǂݍ��ݎ��Ɏ��s�����
    /// </summary>
    /// <param name="nextScene">�ǂݍ��܂ꂽ�V�[��</param>
    /// <param name="mode"></param>
    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        PlayBGM(0);
    }
    /// <summary>
    /// SE���Đ�����
    /// </summary>
    /// <param name="index">SE�p�z��̗v�f�ԍ�</param>
    public void PlaySE(int index)
    {
        if(index < 0) index = 0;
        index %= _seClip.Length;
        if (_seClip[index] == null) return;
        _se.PlayOneShot(_seClip[index]);
    }
    /// <summary>
    /// BGM���Đ�����
    /// </summary>
    /// <param name="index">BGM�p�z��̗v�f�ԍ�</param>
    public void PlayBGM(int index)
    {
        if (index < 0) index = 0;
        index %= _bgmClip.Length;
        if (_bgmClip[index] == null) return;
        _bgm.clip = _bgmClip[index];
        _bgm.Play();
    }
    /// <summary>
    /// BGM�̈ꎞ��~��؂�ւ���
    /// </summary>
    /// <param name="flag">�ꎞ��~���邩������������邩�̃t���O</param>
    public void PauseBGM(bool flag)
    {
        if(flag)
        {
            _bgm.Pause();
        }
        else
        {
            _bgm.UnPause();
        }
    }
    /// <summary>
    /// BGM�����S��~������
    /// </summary>
    public void StopBGM()
    {
        _bgm.Stop();
    }
}
