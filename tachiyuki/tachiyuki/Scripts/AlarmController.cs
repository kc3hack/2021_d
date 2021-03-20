using UnityEngine;

public class AlarmController : MonoBehaviour
{
    const string ACTION_SET_ALARM = "android.intent.action.SET_ALARM";
    const string EXTRA_HOUR = "android.intent.extra.alarm.HOUR";
    const string EXTRA_MINUTES = "android.intent.extra.alarm.MINUTES";
    const string EXTRA_MESSAGE = "android.intent.extra.alarm.MESSAGE";

    public void OnClick()
    {
        print("Hello!");
        CreateAlarm("My alarm!", 8, 52);
    }

    public void CreateAlarm(string message, int hour, int minutes)
    {
        var intentAJO = new AndroidJavaObject("android.content.Intent", ACTION_SET_ALARM);
        intentAJO
            .Call<AndroidJavaObject>("putExtra", EXTRA_MESSAGE, message)
            .Call<AndroidJavaObject>("putExtra", EXTRA_HOUR, hour)
            .Call<AndroidJavaObject>("putExtra", EXTRA_MINUTES, minutes);

        GetUnityActivity().Call("startActivity", intentAJO);
    }

    AndroidJavaObject GetUnityActivity()
    {
        using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        }
    }
}
