using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseTwitter : MonoBehaviour
{
    public void Tweet(){
        Application.OpenURL($"https://twitter.com/intent/tweet?text=今起きた\n&hashtags=眠い");
    }
}
