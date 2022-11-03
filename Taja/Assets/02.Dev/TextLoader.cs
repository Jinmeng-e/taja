using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace Transcribe
{
    public class TextLoader : MonoBehaviour
    {
        [SerializeField] TextAsset asset;

        // TODO : load text with network.
        // JsonUtility doesn't support dictonary
        // https://stackoverflow.com/questions/71664312/using-unity-plastic-newtonsoft-json-not-found-in-rider
        public Book Book;

        public void ReadString(Action<Book> callback)
        {
            var text = asset.ToString();

            Book = JsonUtility.FromJson<Book>(text);
            Book.Init(callback);
        }
    }
    public class Page
    {
        public int Count = 0;
        public List<string> lines = new List<string>();

        public void Add(string str)
        {
            if (string.IsNullOrEmpty(str)) { return; }
            lines.Add(str);
            Count += str.Length;
        }
    }
    [System.Serializable]
    public class Chapter
    {
        public int Count;
        public int index;
        public string name;
        public string contents;
        public List<Page> pages = new List<Page>();

        public void Init()
        {
            var lines = contents.Split("\\n");

            var lineCount = 0;
            while(lines.Length > lineCount )
            {
                var page = new Page();
                for (int i = 0; i < 20; ++i)
                {
                    if(lines.Length <= lineCount) { break; }
                    page.Add(lines[lineCount]);
                    lineCount++;
                }
                Count += page.Count;
                pages.Add(page);
            }
        }
        public Page GetPage(int page)
        {
            Debug.Log($"GetPage {pages.Count}");
            if (pages.Count <= page) { return null; }

            return pages[page];
        }
    }
    [System.Serializable]
    public class Book
    {
        public List<Chapter> chapters = new List<Chapter>();

        public void Init(Action<Book> callback)
        {
            foreach(var c in chapters)
            {
                c.Init();
            }
            callback?.Invoke(this);
        }
        public List<string> GetPage(int chapter,int page)
        {
            Debug.Log($"GetPage {chapter} {page}");
            var index = chapter - 1;
            if(index >= chapters.Count || chapters[index].GetPage(page - 1) == null) { return null; }

            return chapters[index].GetPage(page - 1).lines;
        }
    }
}