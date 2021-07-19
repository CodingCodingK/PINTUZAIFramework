using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ItemMessagePanel : BasePanel
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        var buttons = transform.Find("CloseButton").GetComponentsInChildren<Button>();
        AddButtonsListener(buttons, OnClosePanel);
    }

    public override void OnEnter()
    {
        base.OnEnter();
        
        // 使用由小到大特效
        transform.localScale = Vector3.zero;
        transform.DOScale(1, 0.5f);
    }

    public override void OnExit()
    {
        //canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        // 由小到大特效
        transform.DOScale(0, 0.5f).OnComplete(()=>
        {
            base.canvasGroup.alpha = 0;
        });
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
