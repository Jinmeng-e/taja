using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Transcribe
{
    public class UI : MonoBehaviour
    {
        public static UI Inst;
        static UI inst;

        public void Awake()
        {
            inst = this;
        }

        public void ShowUI()
        {
        }
    }
}
