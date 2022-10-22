using UnityEngine;
using UnityEngine.UI;

public class Toggle_PhraseBottom : MonoBehaviour
{
    [SerializeField] Button btn;
    [SerializeField] GameObject objChackMark;
    [SerializeField] Text[] txtNumber;

    ToggleGroup_PhraseBottom group;

    public bool IsOn
    {
        get { return objChackMark.activeSelf; }
        set { objChackMark.SetActive(value); }
    }
    public void Init(int num, ToggleGroup_PhraseBottom group)
    {
        this.group = group;
        foreach(var t in txtNumber)
        {
            t.text = $"{num}";
        }
    }
    private void Awake()
    {
        btn.onClick.AddListener(() => group.SetToggleOn(this));
    }
}
