using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SleepAlbum")]
public class SleepAlbum : ScriptableObject
{
    struct aaa
    {
        public int settime;
        public int getuptime;
        public int gamescore;
        public Sprite woll;
    }
    Queue<string> aa;
}
