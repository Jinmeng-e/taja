using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Transcribe
{
    public class Main : MonoBehaviour
    {
        public static Main Inst => inst;
        static Main inst;


        [SerializeField] Image innerBG;
        [SerializeField] Image BG;

        private void Awake()
        {
            inst = this;
        }

        public void OnInnerColorChanged(Color color)
        {
            innerBG.color = color ;
        }
        public void OnBGChanged(Sprite sprite)
        {
            BG.sprite = sprite;
        }
        //Get UserData
        //Get BookData
        //ShowMain
        //
    }
}
