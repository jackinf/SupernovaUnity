﻿using System;
using UnityEngine;

public enum Buttons
{
    Right,
    Left,
    Up,
    Down,
    A,
    B
}

public enum Condition
{
    GreaterThan,
    LessThan
}

[Serializable]
public class InputAxisState
{
    public string axisName;
    public float offValue;
    public Buttons button;
    public Condition condition;

    public bool value
    {
        get
        {
            var val = Input.GetAxis(axisName);
            switch (condition)
            {
                case Condition.GreaterThan:
                    return val > offValue;
                case Condition.LessThan:
                    return val < offValue;
            }
            return false;
        }
    }
}

public class InputManager : Singleton<InputManager>
{
    protected InputManager() { }

    public InputAxisState[] inputs;

    public InputState inputState;

    void Update()
    {
        foreach (var input in inputs)
        {
            inputState.SetButtonValue(input.button, input.value);
        }
    }
}
