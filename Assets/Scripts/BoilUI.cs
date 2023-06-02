using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoilUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _warningText;

    private void Awake()
    {
        PushButtonFirstStand.OnButtonClick += ChangeText;
        PushButtonSecondStand.OnButtonClick += ChangeText;
        PushButtonTherdStand.OnButtonClick += ChangeText;
        PushButtonFourthStand.OnButtonClick += ChangeText;
        PushButtonSixStand.OnButtonClick += ChangeText;
    }

    private void ChangeText(int code)
    {
        if (code != 0)
        {
            _warningText.text = code.ToString();
        }
        else
        {
            _warningText.text = " ";
        }

    }
}
