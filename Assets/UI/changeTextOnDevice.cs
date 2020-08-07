using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeTextOnDevice : MonoBehaviour
{
    Text m_text;
    public string PCMessage;
    public string MobileMessage;

    private void Start()
    {
        m_text = GetComponent<Text>();
    }

    private void Update()
    {
        if(SystemInfo.deviceType == DeviceType.Handheld)
        {
            m_text.text = MobileMessage;
        }
        else
        {
            m_text.text = PCMessage;
        }
    }
}
