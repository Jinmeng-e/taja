using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Transcribe
{
    public class UI_Line : MonoBehaviour
    {
        [SerializeField] Color wrong;
        [SerializeField] Color normal;
        [SerializeField] Color hide;
        [SerializeField] TMP_InputField baseIF;
        char[] baseCharArr ;

        string Normal => ColorUtility.ToHtmlStringRGB(normal);
        string Wrong => ColorUtility.ToHtmlStringRGB(wrong);
        string None => ColorUtility.ToHtmlStringRGB(Color.white);

        [SerializeField]TMP_InputField inputIF;
        [SerializeField] TextMeshProUGUI text;
        string inputText;

        public void Init(string line)
        {
            baseCharArr = line.ToCharArray();
            baseIF.text = line;
            inputIF.onValueChanged.AddListener(OnValueChaged);
            inputIF.onFocusSelectAll = false;
        }
        public void Select(bool isSelected)
        {
            Debug.Log($"Select {gameObject.name} {isSelected}");
            if (isSelected)
            {
                inputIF.ActivateInputField();
            }
            else
            {
                inputIF.ReleaseSelection();
            }
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

        public void OnValueChaged(string input)
        {
            Debug.Log($"OnValueChanged :: {input}");
            if (input.Length > baseCharArr.Length) { Main.Inst.NextLine(true); return; }

                var inputC = input.ToCharArray();

            var isCorrect = None;
            var strResult = "";

            for (int i = 0; i < inputC.Length; ++i)
            {
                var now = inputC[i] == baseCharArr[i] ? Normal : Wrong;
                if (now != isCorrect)
                {
                    isCorrect = now;
                    //change state
                    if (i > 0)
                    {
                        strResult += "</color>";
                    }
                    strResult += $"<color=#{now}>";
                }
                strResult += inputC[i];

                if (inputC.Length - 1 == i)
                {
                    strResult += "</color>";
                }
            }
            text.text = strResult;
            if (input.Length == 0)
            {
                Main.Inst.NextLine(false);
            }
            else if (input.Length == baseCharArr.Length)
            {
                Main.Inst.NextLine(true);
            }
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