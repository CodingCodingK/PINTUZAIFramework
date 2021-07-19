using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanel : BasePanel
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        var buttons = transform.Find("CloseButton").GetComponentsInChildren<Button>();
        AddButtonsListener(buttons, OnClosePanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnClosePanel() 
    {
        UIManager.Instance().PopPanel();
    }
}
