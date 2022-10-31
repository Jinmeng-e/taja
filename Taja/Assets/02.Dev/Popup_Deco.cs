using UnityEngine;
using UnityEngine.UI;

namespace Transcribe
{
    public class Popup_Deco : MonoBehaviour
    {
        [SerializeField] Button buttonClose;
        [SerializeField] Toggle toggleKeyboard;
        [SerializeField] Text textKeyboard;
        [SerializeField] Text textBook;
        [SerializeField] Color colorSelected;
        [SerializeField] Color colorNormal;
        [SerializeField] GameObject objKeyboard;
        [SerializeField] GameObject objBook;


        private void Awake()
        {
            buttonClose.onClick.AddListener(onClickClose);
            toggleKeyboard.onValueChanged.AddListener(onSelectKeyboard);
        }
        private void onClickClose()
        {
            gameObject.SetActive(false);
        }
        private void onSelectKeyboard(bool isOn)
        {
            objKeyboard.SetActive(isOn);
            objBook.SetActive(!isOn);
            textKeyboard.color = isOn ? colorSelected : colorNormal;
            textBook.color = isOn ? colorNormal : colorSelected;
        }
    }
}
