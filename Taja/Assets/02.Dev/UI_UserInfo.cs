using UnityEngine;
using UnityEngine.UI;

namespace Transcribe
{
    public class UserInfo
    {
        public Sprite Profile => getProfile();
        public string Name;
        public int Point;

        string name;
        int point;
        Texture2D profile;

        public UserInfo(Texture2D profile, string name, int point)
        {
            this.name = name;
            this.point = point;
            this.profile = profile;
        }
        Sprite getProfile()
        {
            var rect = new Rect(0, 0, profile.width, profile.height);
            return Sprite.Create(profile, rect, new Vector2(0.5f, 0.5f));
        }
    }


    public class UI_UserInfo : MonoBehaviour
    {
        [SerializeField] Image profile;
        [SerializeField] Text userName;
        [SerializeField] Text point;
        public void Set(UserInfo info)
        {
            userName.text = info.Name;
            point.text = $"{info.Point} P"; 
            profile.sprite = info.Profile;
        }
    }
}
