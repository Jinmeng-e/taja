using UnityEngine;
using UnityEngine.UI;

namespace Transcribe
{

    public class Popup_Setting : MonoBehaviour
    {
        [SerializeField] Slider sliderBGM;
        [SerializeField] Slider sliderSFX;
        [SerializeField] Toggle toggleKR;
        [SerializeField] Toggle toggleEN;

        [SerializeField] Text textKR;
        [SerializeField] Text textEN;

        [SerializeField] Color colorSelected;
        [SerializeField] Color colorNormal;

        [SerializeField] GameObject objGroupEn;
        [SerializeField] GameObject objGroupKR;

        private void Awake()
        {
            toggleEN.onValueChanged.AddListener(onEnglishSelected);
        }

        void onEnglishSelected(bool isOn)
        {
            objGroupEn.SetActive(isOn);
            objGroupKR.SetActive(!isOn);

            textKR.color = isOn ? colorNormal : colorSelected;
            textEN.color = isOn ? colorSelected : colorNormal;
        }

    }
}

