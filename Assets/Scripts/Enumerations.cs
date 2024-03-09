using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enumerations
{
   public enum UIState
    {
        Start=0,
        Pause=1,
        Playing=2,
        Winning=3,
        Losing=4
    }
    private static Enumerations.UIState enums;
   

    public static Enumerations.UIState getInstance()
    {
        return enums;
    }
    public static void SetInstance(UIState state)
    {
        enums = state;
    }
}
