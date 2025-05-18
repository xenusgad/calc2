using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Calculator : MonoBehaviour
{
    public static UnityEventString EButtonPressed;
    public static UnityEventLong ECalculationPerformed = new();
    public static UnityEvent EWrongButtonPressed = new();
    private readonly int maxCharCount = 15;
    [SerializeField] private TextMeshProUGUI display;
    private void Start()
    {
        EButtonPressed = new UnityEventString();
        EButtonPressed.AddListener(DefineAction);
        display.text = "0";
    }
    [SerializeField]
    public void DefineAction(string button)
    {
        if (button == CalcButtons.Backspace)
        {
            BackSpace();
            return;
        }
        if (button == CalcButtons.Equal)
        {
            if ("nuh uh bro".Contains(display.text))
            {
                Debug.LogWarning("Incorrect Input");
                return;
            }
            Calculate();
            return;
        }
        if (display.text.Length >= maxCharCount)
        {
            Debug.LogWarning("Not Enough Space");
            return;
        }
        if ("0123456789".Contains(button))
        {
            WriteNum(button);
        }
        else if (CalcButtons.Opers.Contains(button))
        {
            WriteAction(button);
        }
        else if (button == CalcButtons.Clear)
        {
            Clear();
        }
        else
        {
            Debug.LogWarning("Unknown button [" + button + "]");
        }
    }
    private void Clear()
    {
        display.text = "0";
    }
    private void BackSpace()
    {
        if (display.text.Length == 1)
        {
            Clear();
        }
        else
        {
            for(int i = 0; i < display.text.Length; i++)
            {
                if(CalcButtons.Opers.Contains(display.text[i]))
                {
                    display.text = display.text[..^1];
                    return;
                }
            }
            display.text = display.text[..^1];
            ECalculationPerformed.Invoke(Convert.ToInt64(display.text));
        }
    }
    private void WriteAction(string button)
    {
        if (CalcButtons.Opers.Contains(display.text[display.text.Length - 1]))
        {
            display.text = display.text.Remove(display.text.Length - 1) + button;
        }
        else
        {
            display.text += button;
        }
    }
    private void WriteNum(string button)
    {
        if (display.text == "0")
        {
            display.text = button;
            ECalculationPerformed.Invoke(Convert.ToInt64(display.text));
        }
        else
        {
            for(int i = 0; i < display.text.Length; i++)
            {
                if(CalcButtons.Opers.Contains(display.text[i]))
                {
                    display.text += button;
                    return;
                }
            }
            display.text += button;
            ECalculationPerformed.Invoke(Convert.ToInt64(display.text));
        }
    }  
    private void Calculate()
    {
        List<string> _operations = new();
        foreach (char i in display.text)
        {
            if (CalcButtons.Opers.Contains(i))
            {
                _operations.Add(i.ToString());
            }
        }
        string[] _nums = display.text.Split(CalcButtons.Operations, StringSplitOptions.None);

        long[] nums = new long[_nums.Length];
        for(int i = 0; i < _nums.Length; i++)
        {
            nums[i] = Convert.ToInt64(_nums[i]);
        }
        long result = nums[0];
        for (int i = 0; i < _nums.Length - 1; i++)
        {
            if (_operations[i] == CalcButtons.Plus)
            {
                result += nums[i + 1];
            }
            else if (_operations[i] == CalcButtons.Minus)
            {
                result -= nums[i + 1];
            }
            else if (_operations[i] == CalcButtons.Multiply)
            {
                result *= nums[i + 1];
            }
            else if (_operations[i] == CalcButtons.Power)
            {
                result = (long)Math.Pow(result, nums[i + 1]);
            }
            else if (_operations[i] == CalcButtons.Mod)
            {
                result %= nums[i + 1];
            }
            else if (_operations[i] == CalcButtons.Div)
            {
                result /= nums[i + 1];
            }
            else if (_operations[i] == CalcButtons.Divide)
            {
                if (nums[i + 1] == 0)
                {
                    display.text = "nuh uh bro";
                    Debug.LogWarning("Dividing by zero");
                    return;
                }
                else if(result % nums[i + 1] == 0)
                {
                    result /= nums[i + 1];
                }
                else
                {
                    display.text = "nuh uh bro";
                    Debug.LogWarning("Not Integer Division");
                    return;
                }
            }
            ECalculationPerformed.Invoke((long)result);
        }
        if(result.ToString().Length > maxCharCount)
        {
            display.text = "nuh uh bro";
            Debug.LogWarning("Not Enough Space");
            return;
        }
        display.text = result.ToString();
    }
}