using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Oshaberi")]
public class Oshaberi : ScriptableObject
{
    [SerializeField] string[] oshaberi;
    public string GetTalk(int id){
        return oshaberi[id];
    }
    public int Count(){
        return oshaberi.Length;
    }
}
