using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager
{
    public static float Volume
    {
        get { 
            return PlayerPrefs.GetFloat(Constants.Prefs.Volume,1f); }
        set { 
            PlayerPrefs.SetFloat(Constants.Prefs.Volume, Mathf.Clamp(value, 0, 1));
        }
    }
}
