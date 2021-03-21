using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kc3.d.nemu.record{
    public struct Record
        {
            public int settime; //起きるつもりだった時間です
            public int getuptime;　//実際に起きた時間です
            public string playgame;　//遊んだゲームです
           public int gamescore;　//ゲームの評価です
            public Sprite wool; //羊です
        }

    [CreateAssetMenu(menuName = "SleepAlbum")]
    public class SleepAlbum : ScriptableObject
    {
        Queue<Record> records;

        /// <summary>
        /// Record型の構造体を記録として追加します（25個以上のデータは古い順から自動的に削除）
        /// </summary>
        public void AddRecoed(Record record){
            records.Enqueue(record);
            if(records.Count > 25) records.Dequeue();
        }
        
        /// <summary>
        /// 睡眠記録をRecord型のキューで返します
        /// </summary>
        public Queue<Record> GetRecords(){
            return records;
        }
    }

}
