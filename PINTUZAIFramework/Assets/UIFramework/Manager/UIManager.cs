using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager:Singleton<UIManager>
{
   /// <summary>
   /// 存储所有Panel的路径
   /// </summary>
   private Dictionary<UIPanelType, string> panelPathDic;

   /// <summary>
   /// 存储所有实例化的面板的BasePanel组件
   /// </summary>
   private Dictionary<UIPanelType, BasePanel> panelDic;

   /// <summary>
   /// 用栈存储显示中的页面
   /// </summary>
   private Stack<BasePanel> panelStack;
   
   private Transform _canvasTransform;
   
   /// <summary>
   /// 用于设置Panel的父子级关系
   /// </summary>
   private Transform CanvasTransform
   {
      get
      {
         if (_canvasTransform == null)
         {
            _canvasTransform = GameObject.Find("Canvas").transform;
         }

         return _canvasTransform;
      }
   }

   private UIManager()
   {
      ParseUIPanelTypeJson();
   }

   #region panelPathDic
   private void ParseUIPanelTypeJson()
   {
      panelPathDic = new Dictionary<UIPanelType, string>();
      
      TextAsset ta = Resources.Load<TextAsset>("UIPanelType");
      var panelInfoList = JsonUtility.FromJson<UIPanelInfoList>(ta.text);
      foreach (var info in panelInfoList.infoList)
      {
         panelPathDic.Add(info.panelType,info.path);
      }
   }

   public string GetPanelPath(UIPanelType pt)
   {
      return panelPathDic.TryGet(pt);
   }
   #endregion
   
   #region panelDic

   /// <summary>
   /// 返回对应Panel实例的BasePanel，如果没有就实例化一个再返回
   /// </summary>
   /// <param name="pt"></param>
   /// <returns></returns>
   private BasePanel GetPanel(UIPanelType pt)
   {
      if (panelDic == null)
      {
         panelDic = new Dictionary<UIPanelType, BasePanel>();
      }

      // BasePanel panel;
      // panelDic.TryGetValue(pt, out panel);
      BasePanel panel = panelDic.TryGet(pt);

      // 如果字典里没有，就找路径，实例化一个新的Panel Prefab，再返回
      if (panel == null)
      {
         string panelPath = GetPanelPath(pt);
         var panelGO = GameObject.Instantiate(Resources.Load(panelPath)) as GameObject;
         panelGO.transform.SetParent(CanvasTransform,false);
         panelDic.Add(pt,panelGO.GetComponent<BasePanel>());
         panel = panelGO.GetComponent<BasePanel>();
      }
      
      return panel;
   }
   #endregion

   #region panelStack

   /// <summary>
   /// 入栈，即把某panel压入panelStack中
   /// </summary>
   public void PushPanel(UIPanelType pt)
   {
      if (panelStack == null)
      {
         panelStack = new Stack<BasePanel>();
      }
      
      BasePanel panel = GetPanel(pt);
      panelStack.Push(panel);
   }
   
   /// <summary>
   /// 出栈，即panelStack弹出最上面的panel出栈
   /// </summary>
   public void PopPanel(UIPanelType pt)
   {
      BasePanel panel = GetPanel(pt);
      
   }

   #endregion
   
}
