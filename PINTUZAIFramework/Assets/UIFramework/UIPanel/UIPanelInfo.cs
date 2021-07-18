using System;
using System.Collections.Generic;

[Serializable]
public class UIPanelInfo
{
   public UIPanelType panelType => (UIPanelType) System.Enum.Parse(typeof(UIPanelType), this.panelTypeString);

   public string panelTypeString;
   public string path;
}

[Serializable]
public class UIPanelInfoList
{
   public List<UIPanelInfo> infoList;
}