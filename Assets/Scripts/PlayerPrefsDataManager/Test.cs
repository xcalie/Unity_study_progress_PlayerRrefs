using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    public int age;
    public string name;
    public float height;
    public bool sex = true;

    public List<int> list;

    public Dictionary<int, int> Keys;

    public ItemInfo iteminfo;

    public List<ItemInfo> items;

    public Dictionary<int, ItemInfo> itemDic;


    public PlayerInfo()
    {

    }

}


public class ItemInfo
{
    public int id;
    public int num;

    public ItemInfo()
    {

    }

    public ItemInfo(int id, int num)
    {
        this.id = id;
        this.num = num;
    }
}


public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();

        PlayerInfo p2 = PlayerPrefsDataManager.Instance.LoadData(typeof(PlayerInfo), "Player1") as PlayerInfo;

        // 模拟逻辑
        p2.age = 18;
        p2.name = "XC";
        p2.height = 1000;
        p2.sex = true;

        p2.items.Add(new ItemInfo(2, 3));
        p2.items.Add(new ItemInfo(4, 4));

        //p2.itemDic.Add(3, new ItemInfo(5, 5));
        //p2.itemDic.Add(4, new ItemInfo(6, 6));

        PlayerPrefsDataManager.Instance.SaveData(p2, "Player1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
