using UnityEngine;
using UnityEngine.UI;

namespace Transcribe
{
    [System.Serializable]
    public class ToggleColoredText
    {
        public Toggle toggle;
        public Text text;
        Color selected;
        Color normal;

        public void Set(Color selected, Color normal)
        {
            this.selected = selected;
            this.normal = normal;
            toggle.onValueChanged.AddListener((on) => text.color = on ? selected : normal);
        }
    }
    public class Library_Like : MonoBehaviour
    {
        [SerializeField] ToggleColoredText[] toggles;
        [SerializeField] Color colorSelected;
        [SerializeField] Color colorNormal;


        private void Awake()
        {
            foreach (var t in toggles)
            {
                t.Set(colorSelected, colorNormal);
            }
        }
    }
}
