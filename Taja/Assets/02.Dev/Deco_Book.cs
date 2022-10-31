using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Transcribe
{
    [System.Serializable]
    public class DecoItem
    {
        public Toggle toggle;
        public Color color;

        public void AddListener(System.Action<Color> callback)
        {
            toggle.onValueChanged.AddListener((b) =>
            {
                if (b) callback?.Invoke(color);
            });
        }
    }
    [System.Serializable]
    public class BGItem
    {
        public Toggle toggle;
        public Sprite sprite;

        public void AddListener(System.Action<Sprite> callback)
        {
            toggle.onValueChanged.AddListener((b) =>
            {
                if (b) callback?.Invoke(sprite);
            });
        }
    }
    public class Deco_Book : MonoBehaviour
    {
        [SerializeField] Button btnAdjust;
        [SerializeField] DecoItem[] toggles;
        [SerializeField] BGItem[] bgToggles;

        [SerializeField] Color colorSelected;
        [SerializeField] Sprite spriteSelected;

        private void Awake()
        {
            btnAdjust.onClick.AddListener(Adjust);
            foreach (var item in toggles)
            {
                item.AddListener((color) => colorSelected = color);
            }
            foreach (var item in bgToggles)
            {
                item.AddListener((sprite) => spriteSelected = sprite);
            }
        }

        private void Adjust()
        {
            Main.Inst.OnInnerColorChanged(colorSelected);
            Main.Inst.OnBGChanged(spriteSelected);
        }
    }
}
