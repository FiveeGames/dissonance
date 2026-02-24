using UnityEngine;

public enum TimeOfDay
{
    Morning,
    Noon,
    Evening,
    Night
}

public class TimeManager : MonoBehaviour
{
    public TimeOfDay currentTime;

    public float timeInterval = 30f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeInterval)
        {
            AdvanceTime();
            timer = 0f;
        }
    }

    void AdvanceTime()
    {
        currentTime = (TimeOfDay)(((int)currentTime + 1) % 4);
        Debug.Log("Time is now: " + currentTime);
    }
}