using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DictionaryExtension 
{
   public static TValue TryGet<TKey, TValue>(this Dictionary<TKey, TValue> dic, TKey key)
   {
      dic.TryGetValue(key,out TValue value);
      return value;
   }
}
