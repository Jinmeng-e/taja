using System;
using UnityEngine;
using UnityEngine.UI;

namespace Transcribe
{
    public enum BookType
    {
        ALL,
        KR_STORY,
        KR_ESSAY,
        KR_CLASSIC,
        EN_STORY
    }
    public class WordInfo
    {
        public int page;
        public int line;
        public int count;

        public WordInfo(int page, int line, int count)
        {
            this.page = page;
            this.line = line;
            this.count = count;
        }
    }
    public class BookInfo
    {
        public BookType Type;
        public string Name;
        public TimeSpan TotalDuration => TimeSpan.FromTicks(totalDuration);
        public int WriteCount => writeCount;
        public int TotalWordCount => totalWordCount;
        public float TotalProgress =>  (float)writeCount / totalWordCount;


        long totalDuration;
        int totalWordCount;
        int writeCount;
        int page;
        WordInfo myPosition;
        WordInfo[] wrongWords;


        public BookInfo(BookType type, string name, long totalDuration, int totalWordCount, int writeCount, int page, WordInfo myPosition)
        {
            this.Type = type;
            this.Name = name;
            this.totalDuration = totalDuration;
            this.totalWordCount = totalWordCount;
            this.writeCount = writeCount;
            this.page = page;
            this.myPosition = myPosition;

            var length = wrongWords.Length;

            wrongWords = new WordInfo[length];
            for(int i = 0; i < length; ++i)
            {
                this.wrongWords[i] = wrongWords[i];
            }
        }
    }

    public class UI_BookInfo : MonoBehaviour
    {
        [SerializeField] Text bookType;
        [SerializeField] Text bookName;
        [SerializeField] Text totalDuration;
        [SerializeField] Text totalProgressCount;
        [SerializeField] Text totalProgress;
        [SerializeField] Image imgProgress;


        public void Set(BookInfo info)
        {
            bookType.text = getBookType(info.Type);
            bookName.text = info.Name;
            totalDuration.text = info.TotalDuration.ToString(@"hh\:mm\:ss");
            totalProgressCount.text = $"{info.WriteCount}/{info.TotalWordCount}";
            totalProgress.text = $"{(int)info.TotalProgress * 100f} %";
            imgProgress.fillAmount = info.WriteCount / info.TotalWordCount;
        }


        private string getBookType(BookType type)
        {
            switch (type)
            {
                case BookType.ALL:
                    return "??????";
                case BookType.KR_STORY:
                    return "??????????????????";
                case BookType.KR_ESSAY:
                    return "??????????????????";
                case BookType.KR_CLASSIC:
                    return "??????????????????";
                case BookType.EN_STORY:
                    return "??????????????????";
            }
            return "";
        }
    }
}
