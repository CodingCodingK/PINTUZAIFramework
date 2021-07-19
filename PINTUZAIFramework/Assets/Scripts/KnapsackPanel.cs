using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class KnapsackPanel : BasePanel
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        var closeButtons = transform.Find("CloseButton").GetComponentsInChildren<Button>();
        AddButtonsListener(closeButtons, OnClosePanel);

        var itemButtons = transform.Find("Slot").GetComponentsInChildren<Button>();
        AddButtonsListener(itemButtons, OnItemButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnEnter()
    {
        base.OnEnter();
        
        // 使用由右弹出特效
        var temp = transform.localPosition;
        temp.x = 600f;
        transform.localPosition = temp;
        transform.DOLocalMoveX(0,0.5f);
    }
    
    public override void OnExit()
    {
        //base.canvasGroup.alpha = 0;
        base.canvasGroup.blocksRaycasts = false;
        
        transform.DOLocalMoveX(600f, 0.5f).OnComplete(()=>
        {
            base.canvasGroup.alpha = 0;
        });
    }

    private void OnClosePanel() 
    {
        UIManager.Instance().PopPanel();
    }
    
    private void OnItemButtonClick() 
    {
        UIManager.Instance().PushPanel(UIPanelType.ItemMessage);
    }
}
