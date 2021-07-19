using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanel : BasePanel
{
    private CanvasGroup canvasGroup;
    public override void OnPause()
    {
        base.OnPause();
    }
    public override void OnResume()
    {
        base.OnResume();
    }

    public void OnPushPanel(UIPanelType panelType)
    {
        UIManager.Instance().PushPanel(panelType);
    }

    // Start is called before the first frame update
    void Start()
    {
        var buttons = transform.Find("IconPanel").GetComponentsInChildren<Button>();
        var buttonsExpectBattleButton = buttons.ToList().Where(o=>o.name!="BattleButton").ToArray();
        AddUIPanelButtonsListener(buttonsExpectBattleButton);

        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddUIPanelButtonsListener(Button[] buttons)
    {
        foreach (var button in buttons)
        {
            var typeString = button.name.Substring(0, button.name.Length - "Button".Length);
            var type = (UIPanelType) System.Enum.Parse(typeof(UIPanelType), typeString);
            button.onClick.AddListener(()=>
            {
                OnPushPanel(type);
            });
        }
    }
}
