using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Transcribe
{
    public class UI_Line : MonoBehaviour
    {
        public string Input
        {
            get { return inputText; }
            set
            {
                inputText = value;
                var txt = inputText.ToCharArray();
                foreach (var s in txt)
                {
                }

            }
        }

        [SerializeField] Color wrong;
        [SerializeField] Color normal;
        [SerializeField] Color hide;
        [SerializeField] TMP_InputField baseIF;
        char[] baseCharArr => baseIF.text.ToCharArray();

        InputField inputIF;
        string inputText;

        public void Init(string line)
        {
            baseIF.text = line;
        }

        bool checkCorrect(int index)
        {
            if (baseCharArr.Length <= index)
            {
                Debug.LogError($"Index Error : {baseCharArr.Length}\n Now : {index}");
                return false;
            }
            var baseChar = baseCharArr[index];

            return false;
        }
    }

    public enum WordState
    {
        Hide,
        Normal,
        Wrong,
    }
    public class Word
    {
        public int start;
        public int end;
        public WordState state;
        public string contents;
    }
    public class TypingCharacter // 작성중인 단어
    {
        public char c;
        public int first;
        public int middle;
        public int last;
        public string normal;
        public string wrong;
        ushort uniCodeKRBase = 0xAC00;
        ushort mUniCodeKRLast = 0xD79F;

        public TypingCharacter(char c, Color normal, Color wrong)
        {
            this.c = c;
            this.normal = ColorUtility.ToHtmlStringRGB(normal);
            this.wrong = ColorUtility.ToHtmlStringRGB(wrong);
            var tempCode = System.Convert.ToUInt16(c);
            var iUniCode = tempCode - uniCodeKRBase;


            if ((tempCode < iUniCode) || (tempCode > mUniCodeKRLast)) // 한글 아님
            {
                first = -1;
                middle = -1;
                last = -1;
            }

            first = iUniCode / (21 * 28);
            iUniCode = iUniCode % (21 * 28);
            middle = iUniCode / 28;
            iUniCode = iUniCode % 28;
            last = iUniCode;
        }

        public string Convert(char input)
        {
            var tempCode = System.Convert.ToUInt16(c);
            var iUniCode = tempCode - uniCodeKRBase;
            var first = 0;
            var middle = 0;
            var last = 0;

            if ((tempCode < iUniCode) || (tempCode > mUniCodeKRLast)) // 한글 아님
            {
                return $"<color=#{wrong}>{input}</color>";
            }

            first = iUniCode / (21 * 28);
            iUniCode = iUniCode % (21 * 28);
            middle = iUniCode / 28;
            iUniCode = iUniCode % 28;
            last = iUniCode;

            if (first != 0 && first != this.first ||
                middle != 0 && middle != this.middle ||
                last != 0 && last != this.last)
            {
                return $"<color=#{wrong}>{input}</color>";
            }

            return $"<color=#{normal}>{input}</color>";
        }
    }
}