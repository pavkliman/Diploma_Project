using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// �����, ����������� 
/// ������������� ���������
/// </summary>
public class PushButtonFourthStand : MonoBehaviour
{
    /// <summary>
    /// ��������� ������� ������
    /// </summary>
    public static Action<int> OnButtonClick;
    /// <summary>
    /// ������������ ������������ �� �����
    /// </summary>
    [SerializeField] private XRSimpleInteractable simpleInteractable;
    /// <summary>
    /// ����� ���� �� ���������
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
    /// ��������, �������� �� ������
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
