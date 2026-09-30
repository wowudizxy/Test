using Luban.SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LubanDemo : MonoBehaviour
{
    [SerializeField] private int _itemId = 1001;
    private cfg.Tables _tables;
    private void Start()
    {
        _tables = new cfg.Tables(LoadJson);
        PrintItem(_itemId);
    }
    private static JSONNode LoadJson(string fileName)
    {
        string path = $"Luban/{fileName}";
        TextAsset asset = Resources.Load<TextAsset>(path);
        if (asset == null)
            throw new FileNotFoundException($"找不到配置资源：Resources/{path}.json");

        return JSON.Parse(asset.text);
    }
    private void PrintItem(int itemId)
    {
        var item = _tables.Tbitem.GetOrDefault(itemId);
        if (item == null)
        {
            Debug.LogWarning($"找不到道具，ID：{itemId}", this);
            return;
        }

        Debug.Log($"道具：{item.Name}，描述：{item.Desc}，数量：{item.Count}", this);
    }
}
