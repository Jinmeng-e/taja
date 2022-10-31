using UnityEngine;

namespace Transcribe
{
    public class Popup_Library : MonoBehaviour
    {
        [SerializeField] ToggleColoredText[] toggles;
        [SerializeField] Color colorSelected;
        [SerializeField] Color colorNormal;
        [SerializeField] GameObject tabAll;
        [SerializeField] GameObject tabLikes;

        private void Awake()
        {
            foreach(var t in toggles)
            {
                t.Set(colorSelected, colorNormal);
            }

            toggles[0].toggle.onValueChanged.AddListener(onSelectedAll);
        }
        private void onSelectedAll(bool isOn)
        {
            tabAll.SetActive(isOn);
            tabLikes.SetActive(!isOn);
        }
    }
}
