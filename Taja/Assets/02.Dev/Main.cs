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
        public UI_Main uiMain;

        [SerializeField] Image innerBG;
        [SerializeField] Image BG;
        private int pageIndex;
        private int lineIndex;
        private int maxLineIndex;

        private void Awake()
        {
            inst = this;
        }
        private void Start()
        {
            LineSelect(0, 0);
        }

        public void LineSelect(int pageIndex,int lineIndex)
        {
            uiMain.LineSelect(pageIndex, lineIndex);
        }
        public void NextLine(bool isNext)
        {
            if (isNext)
            {
                //check last line in page
                //check last page in book

                if (lineIndex == 19) // nextpage
                {
                    lineIndex = 0;
                    ++pageIndex;
                    // set page;
                }
                else
                {
                    ++lineIndex;
                }
            }
            else
            {
                if(lineIndex == 0) // prevPage
                {
                    if (pageIndex == 0) return;
                    else
                    {
                        // if changePage, check auto;
                        pageIndex--;
                    }
                }
                else
                {
                    --lineIndex;
                }
            }
            uiMain.LineSelect(pageIndex, lineIndex);
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
