using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

namespace kc3.d.tz.alarm {
    public class NotificationManager {
        /// <summary>
        /// チャンネルの登録
        /// </summary>
        /// <param name="cannelId"></param>
        /// <param name="title">通知のタイトル</param>
        /// <param name="description">本文</param>
        public static void RegisterChannel() {
            var c = new AndroidNotificationChannel() {
                Id = "channel_id",
                Name = "Default Channel",
                Importance = Importance.High,
                Description = "Generic notifications",
            };
            AndroidNotificationCenter.RegisterNotificationChannel(c);
        }
        /// <summary>
        /// 通知削除
        /// </summary>
        public static void AllClear() {
            AndroidNotificationCenter.CancelAllScheduledNotifications();
            AndroidNotificationCenter.CancelAllNotifications();
        }

        /// <summary>
        /// タイマーセットしたら呼び出される。通知登録。
        /// </summary>
        /// <param name="remainTime">指定時間までの差分　通知の設定時間に使う</param>
        public static void SetNotification(int remainTime) {
            AllClear();
            var notification = new AndroidNotification();
            notification.Title = "羊牧場";
            notification.Text = "朝だメェ！一緒に遊んで羊を育てよう！";
            notification.FireTime = System.DateTime.Now.AddMinutes(remainTime);

            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }
    }
}