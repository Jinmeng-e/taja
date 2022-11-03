using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Transcribe
{
    public class UI_Main : MonoBehaviour
    {
        [SerializeField] Transform parent;
        [SerializeField] UI_Line[] lines;
        [SerializeField] UI_Line line;
        [SerializeField] TextLoader loader;
        Book book;

        public void Awake()
        {
            loader.ReadString(ReadEnd);
        }

        public void ReadEnd(Book book)
        {
            Debug.Log("READ END");
            this.book = book;

            var strArr = book.GetPage(1, 1);

            for(int i = 0; i < lines.Length; ++i)
            {
                lines[i].Init(strArr[i]);
            }
            //foreach(var c in book.chapters)
            //{
            //    foreach(var p in c.pages)
            //    {
            //        foreach(var l in p.lines)
            //        {
            //            Debug.Log(l);
            //        }
            //    }
            //}
        }
    }
}
