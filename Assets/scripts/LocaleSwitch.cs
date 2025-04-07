using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSwitch : MonoBehaviour
{
    private int currentLocale = 0;

    // Start is called before the first frame update
    void Start()
    {
        getNumberCurrentLocale();
    }

    public void SwitchLocale()
    {
        currentLocale = currentLocale+2 <= LocalizationSettings.AvailableLocales.Locales.Count ? +1 : 0;
        SetLocale(currentLocale);
    }

    private void SetLocale(int number)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[number];
    }

    private void getNumberCurrentLocale()
    {
        for(int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; i++)
        {
            if(LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[i])
            {
                currentLocale = i;
                return;
            }

        }
    }
}
