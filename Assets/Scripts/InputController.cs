using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private static InputController _instance;

    public static InputController instance
    {
        get
        {
            if (InputController._instance == null)
                InputController._instance = FindObjectOfType<InputController>();

            return InputController._instance;
        }
    }

    public delegate void RightClickEvent(bool clicked);
    public event RightClickEvent onRightClickClicked;

    public event RightClickEvent onRightClickUnclicked;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (this.onRightClickClicked != null)
                this.onRightClickClicked.Invoke(true);
        }

        if (Input.GetMouseButtonUp(1))
        {
            if (this.onRightClickUnclicked != null)
                this.onRightClickUnclicked.Invoke(false);
        }
    }

}
