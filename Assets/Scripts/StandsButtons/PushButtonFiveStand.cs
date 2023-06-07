using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.XR.Interaction.Toolkit;
using System;

/// <summary>
/// ����� ��� ������������
/// ������ �����
/// </summary>
public class PushButtonFiveStand : MonoBehaviour
{
    /// <summary>
    /// ��������� �����������
    /// ����
    /// </summary>
    public static Action<bool> OnShowWaterFlow;

    [SerializeField] private XRSimpleInteractable simpleInteractable;
    [SerializeField] private ParticleSystem _flareEffect;

    private bool _isPressed = false;

    private void Awake()
    {
        simpleInteractable.selectEntered.AddListener(OnSelectEntered);
    }
    /// <summary>
    /// ��������, ������ 
    /// �� ������
    /// </summary>
    /// <param name="args"></param>
    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (!_isPressed)
        {
            _isPressed = true;
            OnShowWaterFlow?.Invoke(true);
            _flareEffect.Play();
        }
        else
        {
            _isPressed = false;
            OnShowWaterFlow?.Invoke(false);
            _flareEffect.Stop();

        }
    }
}
