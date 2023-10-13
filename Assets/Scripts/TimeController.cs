using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float slowDownFactor = 0.05f;
    public float bulletTimeLength = 2f;


    private static TimeController _instance;
    private float? startBulletTime;
    private float? endBulletTime;

    public static TimeController instance
    {
        get
        {
            if (TimeController._instance == null)
                TimeController._instance = FindObjectOfType<TimeController>();

            return TimeController._instance;
        }
    }

    public void Update()
    {
        //Pas de end bullet time donc pas de descente
        if(startBulletTime != null && endBulletTime == null)
        {
            this.doSlowMo();
        }

        //end bullet set donc MouseUp = debut de la descente
        if(startBulletTime != null && endBulletTime >= startBulletTime)
        {
            this.endSlowMo();
        }
    }


    public void doSlowMo()
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    public void endSlowMo()
    {
        Debug.Log("End slow mo");
        Time.timeScale += (1f / bulletTimeLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void toggleBulletTime(bool active)
    {
        if (active)
        {
            this.startBulletTime = Time.time;
            this.endBulletTime = null;
            TimeController.instance.doSlowMo();
        }
        else
        {
            this.startBulletTime = Time.time;
            this.endBulletTime = Time.time + bulletTimeLength;
        }

    }

    public void Awake()
    {
        InputController.instance.onRightClickClicked += this.toggleBulletTime;
        InputController.instance.onRightClickUnclicked += this.toggleBulletTime;
    }
}
