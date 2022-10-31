using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace Transcribe
{
    public enum RightMenuType
    {
        None,
        Setting,
        Library,
        Deco,
        Help,
    }

    public class UI_RightMenu : MonoBehaviour
    {
        [SerializeField] Button btnClose;
        [SerializeField] Button btnBook;
        [SerializeField] Button btnSetting;
        [SerializeField] Button btnLibrary;
        [SerializeField] Button btnDeco;
        [SerializeField] Button btnHelp;

        [SerializeField] GameObject objSetting;
        [SerializeField] GameObject objLibrary;
        [SerializeField] GameObject objDeco;

        [SerializeField] Color colorSelected;
        [SerializeField] Color colorNormal;

        Graphic graphicBook;
        Graphic[] graphicSetting;
        Graphic[] graphicLibrary;
        Graphic[] graphicDeco;
        Graphic[] graphicHelp;

        RightMenuType showType = RightMenuType.None;


        private void Awake()
        {
            graphicBook = btnClose.image;
            graphicSetting = btnSetting.GetComponentsInChildren<Graphic>();
            graphicLibrary = btnLibrary.GetComponentsInChildren<Graphic>();
            graphicDeco = btnDeco.GetComponentsInChildren<Graphic>();
            graphicHelp = btnHelp.GetComponentsInChildren<Graphic>();

            btnClose.onClick.AddListener(onClickClose);
            btnBook.onClick.AddListener(onClickBook);
            btnSetting.onClick.AddListener(onClickSetting);
            btnLibrary.onClick.AddListener(onClickLibrary);
            btnDeco.onClick.AddListener(onClickDeco);
            btnHelp.onClick.AddListener(onClickHelp);
        }
        private void onClickClose()
        {
        }
        private void onClickBook()
        {
            // TODO 겹쳐쓰기 모아쓰기
        }
        private void onClickSetting()
        {
            Debug.Log($"onClickSetting{showType}");
            //if (showType == RightMenuType.Setting) return;
            var prevType = showType;
            buttonDeselect(prevType);

            showType = RightMenuType.Setting;
            buttonSelect(graphicSetting, true);

            objSetting.SetActive(true);
        }
        private void onClickLibrary()
        {
            Debug.Log($"onClickLibrary{showType}");
            //if (showType == RightMenuType.Library) return;
            var prevType = showType;
            buttonDeselect(prevType);

            showType = RightMenuType.Library;
            buttonSelect(graphicLibrary, true);

            objLibrary.SetActive(true);
        }
        private void onClickDeco()
        {
            Debug.Log($"onClickDeco{showType}");
            //if (showType == RightMenuType.Deco) return;
            var prevType = showType;
            buttonDeselect(prevType);

            showType = RightMenuType.Deco;
            buttonSelect(graphicDeco, true);

            objDeco.SetActive(true);
        }
        private void onClickHelp()
        {
            Debug.Log($"onClickHelp{showType}");
            //if (showType == RightMenuType.Help) return;
            var prevType = showType;
            buttonDeselect(prevType);

            showType = RightMenuType.Help;
            buttonSelect(graphicHelp, true);
            // TODO Help
        }
        public void onClickClosePopup()
        {
            buttonDeselect(showType);
        }


        private void buttonDeselect(RightMenuType type)
        {
            switch (type)
            {
                case RightMenuType.Setting:
                    buttonSelect(graphicSetting, false);
                    objSetting.SetActive(false);
                    break;
                case RightMenuType.Library:
                    buttonSelect(graphicLibrary, false);
                    objLibrary.SetActive(false);
                    break;
                case RightMenuType.Deco:
                    buttonSelect(graphicDeco, false);
                    objDeco.SetActive(false);
                    break;
                case RightMenuType.Help:
                    buttonSelect(graphicHelp, false);
                    break;
            }
        }
        private void buttonSelect(Graphic[] graphics, bool selected)
        {
            var color = selected ? colorSelected : colorNormal;
            foreach (var g in graphics) { g.color = color; }
        }
    }
}