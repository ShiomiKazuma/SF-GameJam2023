using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [Header("SE用オーディオソース")] public AudioSource _se;
    [Header("BGM用オーディオソース")] public AudioSource _bgm;
    [Header("SE用音源"), SerializeField] AudioClip[] _seClip;
    [Header("BGM用音源"), SerializeField] AudioClip[] _bgmClip;
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
    /// シーン読み込み時に実行される
    /// </summary>
    /// <param name="nextScene">読み込まれたシーン</param>
    /// <param name="mode"></param>
    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        PlayBGM(0);
    }
    /// <summary>
    /// SEを再生する
    /// </summary>
    /// <param name="index">SE用配列の要素番号</param>
    public void PlaySE(int index)
    {
        if(index < 0) index = 0;
        index %= _seClip.Length;
        if (_seClip[index] == null) return;
        _se.PlayOneShot(_seClip[index]);
    }
    /// <summary>
    /// BGMを再生する
    /// </summary>
    /// <param name="index">BGM用配列の要素番号</param>
    public void PlayBGM(int index)
    {
        if (index < 0) index = 0;
        index %= _bgmClip.Length;
        if (_bgmClip[index] == null) return;
        _bgm.clip = _bgmClip[index];
        _bgm.Play();
    }
    /// <summary>
    /// BGMの一時停止を切り替える
    /// </summary>
    /// <param name="flag">一時停止するかそれを解除するかのフラグ</param>
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
    /// BGMを完全停止させる
    /// </summary>
    public void StopBGM()
    {
        _bgm.Stop();
    }
}
