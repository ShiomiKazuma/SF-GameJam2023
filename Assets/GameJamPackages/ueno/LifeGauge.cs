using UnityEngine;
using UnityEngine.UI;

public class LifeGauge : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] PlayerHp _player;
    public void Damaged()
    {
        _slider.value = _player._curentHp;
    }

    void Start()
    {
        _slider.maxValue = _player._maxHp;
        _slider.value = _player._curentHp;
    }
}
