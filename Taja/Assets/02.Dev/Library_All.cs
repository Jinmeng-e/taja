using UnityEngine;

namespace Transcribe
{
    public class Library_All : MonoBehaviour
    {
        [SerializeField] ToggleColoredText[] toggleTypes;

        [SerializeField] Color colorSelected;
        [SerializeField] Color colorNormal;

        private void Awake()
        {
            foreach(var t in toggleTypes)
            {
                t.Set(colorSelected, colorNormal);
            }
        }
    }
}
