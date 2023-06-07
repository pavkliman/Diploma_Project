using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Класс, реализующий 
/// неисправность электрода
/// </summary>
public class PushButtonFourthStand : MonoBehaviour
{
    /// <summary>
    /// Обработка события кнопки
    /// </summary>
    public static Action<int> OnButtonClick;
    /// <summary>
    /// Демонстрация неиспраности на котле
    /// </summary>
    [SerializeField] private XRSimpleInteractable simpleInteractable;
    /// <summary>
    /// Показ искр от электрода
    /// </summary>
    [SerializeField] private ParticleSystem _flareEffect;
    [SerializeField] private Outline _objectOutline;
    [SerializeField] private int _warningCode;

    private bool _isPressed = false;

    private void Awake()
    {
        simpleInteractable.selectEntered.AddListener(OnSelectEntered);
    }
    /// <summary>
    /// Проверка, включена ли кнопка
    /// </summary>
    /// <param name="args"></param>
    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (!_isPressed)
        {
            _isPressed = true;
            _objectOutline.enabled = true;

            _flareEffect.Play();
            OnButtonClick?.Invoke(_warningCode);

        }
        else
        {
            _isPressed = false;
            _objectOutline.enabled = false;
            OnButtonClick?.Invoke(0);

            _flareEffect.Stop();
        }
    }
}
