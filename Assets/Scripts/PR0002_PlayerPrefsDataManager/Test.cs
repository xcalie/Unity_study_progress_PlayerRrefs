using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    public int age = 10;
    public string name = "未命名";
    public float height = 177.5f;
    public bool sex = true;

    public List<int> list = new List<int>();

    public Dictionary<int, int> Keys = new Dictionary<int, int>();

    public ItemInfo iteminfo = new ItemInfo(3,99);

    public List<ItemInfo> items = new List<ItemInfo>() {
        new ItemInfo(3, 22),
        new ItemInfo(4, 33)
    };

    public Dictionary<int, ItemInfo> itemDic = new Dictionary<int, ItemInfo>() {
        {3, new ItemInfo(3,123) },
        {4, new ItemInfo(4, 444) },
    };



    public PlayerInfo(params int[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            this.list.Add(list[i]);
        }
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
        PlayerInfo info = new PlayerInfo(2,3,4,5);
        info.Keys.Add(2, 3);
        info.Keys.Add(3, 8);
        PlayerPrefsDataManager.Instance.SaveData(info, "Player1");

        PlayerInfo info1 = PlayerPrefsDataManager.Instance.LoadData(typeof(PlayerInfo), "Player1") as PlayerInfo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
