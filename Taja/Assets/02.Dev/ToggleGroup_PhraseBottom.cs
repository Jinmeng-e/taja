using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGroup_PhraseBottom : MonoBehaviour
{
    public int Page
    {
        get { return index + 1; }
        set
        {
            adjust(value);
        }
    }

    [SerializeField] Toggle_PhraseBottom origin;
    List<Toggle_PhraseBottom> toggles;

    private int index = 0;
    private void adjust(int page)
    {
        var next = page - 1;
        if (index == next) { return; }

        toggles[index].IsOn = false;
        toggles[next].IsOn = true;
        index = next;
    }
    public void SetToggleOn(Toggle_PhraseBottom toggle)
    {
        var index = toggle.transform.GetSiblingIndex();
        Page = index;
    }
    public void InitToggles(int total, int saved) // get total page and Now
    {
        for (int i = 0; i < total; ++i)
        {
            var index = i;
            AddToggle(index, i == saved - i);
        }
    }
    public void AddToggle(int index, bool isOn)
    {
        if (toggles == null)
        {
            toggles = new List<Toggle_PhraseBottom>();
        }
        var t = Instantiate(origin, this.transform);
        t.gameObject.SetActive(true);
        t.Init(index, this);
        t.IsOn = isOn;
        toggles.Add(t);
    }
}
