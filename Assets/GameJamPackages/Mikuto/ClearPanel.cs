using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPanel : MonoBehaviour
{
    [SerializeField] GameObject[] _panels;
    private void Start()
    {
        StartCoroutine(ChangePanel());
    }
    void SwitchScene(int index)
    {
        foreach (GameObject panel in _panels)
        {
            panel.SetActive(false);
        }
        _panels[index].SetActive(true);
    }

    IEnumerator ChangePanel()
    {
        SwitchScene(0);
        yield return new WaitForSeconds(1);
        SwitchScene(1);

    }
}
