using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BasePanel : MonoBehaviour
{
    protected CanvasGroup canvasGroup;

    public void Start()
    {
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
    }

    /// <summary>
    /// 界面显示
    /// </summary>
    public virtual void OnEnter()
    {
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();

        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }
    
    /// <summary>
    /// 界面暂停
    /// </summary>
    public virtual void OnPause()
    {
        canvasGroup.blocksRaycasts = false;
    }
    
    /// <summary>
    /// 界面从暂停中恢复
    /// </summary>
    public virtual void OnResume()
    {
        canvasGroup.blocksRaycasts = true;
    }
    
    /// <summary>
    /// 界面关闭
    /// </summary>
    public virtual void OnExit()
    {
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
        
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }
    
    /// <summary>
    /// 给Button[]进行事件注册的方法
    /// </summary>
    /// <param name="buttons"></param>
    /// <param name="call"></param>
    protected void AddButtonsListener(Button[] buttons,UnityAction call)
    {
        foreach (var button in buttons)
        {
            button.onClick.AddListener(call);
        }
    }
}
