using UnityEngine;
using UnityEngine.UI;

namespace Transcribe
{
    public class Main_FloatingMenu : MonoBehaviour
    {
        [SerializeField] Toggle toggleAuto;
        [SerializeField] Button buttonErase;
        [SerializeField] Button buttonMarker;
        [SerializeField] Button buttonOverlap;
        [SerializeField] Button buttonExpend;



        private void Awake()
        {
            toggleAuto.onValueChanged.AddListener(onValueChanged);
            buttonErase.onClick.AddListener(onEraseClicked);
            buttonMarker.onClick.AddListener(onMarkerClicked);
            buttonOverlap.onClick.AddListener(onOverlapClicked);
            buttonExpend.onClick.AddListener(onExpendClicked);
        }
        private void onValueChanged(bool isOn)
        {

        }
        private void onEraseClicked()
        {

        }
        private void onMarkerClicked()
        {

        }
        private void onOverlapClicked()
        {

        }
        private void onExpendClicked()
        {

        }
    }
}
