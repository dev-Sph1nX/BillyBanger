using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float slowDownFactor = 0.05f;
    public float stamina = 1f;
    public float pasStamina = 0.1f;

    private static TimeController _instance;
    private float? startBulletTime;
    private float? endBulletTime;
    private float _pas;

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
        if (_pas < 0)
        {
            if (stamina <= 0)
            {
                toggleBulletTime(false);
            }
            else
            {
                stamina += _pas * Time.deltaTime;
            }

        }
        else
        {
            if (stamina <= 1)
            {
                stamina += _pas * Time.deltaTime;
            }
            else
            {
                stamina = 1;
            }
        }
    }


    public void doSlowMo()
    {
        ChunkController.Instance.SlowSpeed(slowDownFactor);
    }

    public void endSlowMo()
    {
        ChunkController.Instance.ResetSpeed();
    }

    public void toggleBulletTime(bool active)
    {
        if (active)
        {
            _pas = -pasStamina;
            doSlowMo();
        }
        else
        {
            _pas = pasStamina;
            endSlowMo();
        }
    }

    public void Awake()
    {
        _pas = -stamina;
        InputController.instance.onRightClickClicked += this.toggleBulletTime;
        InputController.instance.onRightClickUnclicked += this.toggleBulletTime;
    }
}
