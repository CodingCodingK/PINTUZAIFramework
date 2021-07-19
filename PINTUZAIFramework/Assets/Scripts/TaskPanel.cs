using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class TaskPanel : BasePanel
{
    //private CanvasGroup canvasGroup;
    
    void Start()
    {
        base.Start();
        var buttons = transform.Find("CloseButton").GetComponentsInChildren<Button>();
        AddButtonsListener(buttons, OnClosePanel);
    }

    public override void OnEnter()
    {
        // 使用渐隐/渐显特效
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
        
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = true;
        base.canvasGroup.DOFade(1,0.5f);
    }

    public override void OnExit()
    {
        canvasGroup.blocksRaycasts = false;
        base.canvasGroup.DOFade(0,0.5f);
    }
    
    private void OnClosePanel() 
    {
        UIManager.Instance().PopPanel();
    }
    
    
}
