using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 排行榜玩家信息
/// </summary>
public class RankInfo
{
    public string playerName;
    public int playerScore;
    public int playerTime;

    public RankInfo(string playerName, int playerScore, int playerTime)
    {
        this.playerName = playerName;
        this.playerScore = playerScore;
        this.playerTime = playerTime;
    }
}


public class RankListInfo
{
    public List<RankInfo> rankList;


    public RankListInfo()
    {
        this.Load();
    }


    /// <summary>
    /// 添加新的排行榜信息
    /// </summary>
    /// <param name="name"></param>
    /// <param name="score"></param>
    /// <param name="time"></param>
    public void Add(string name, int score, int time)
    {
        rankList.Add(new RankInfo(name, score, time));
    }

    public void Save()
    {
        // 存储多少条数据
        PlayerPrefs.SetInt("rankListNum", rankList.Count);
        for (int i = 0; i < rankList.Count; i++)
        {
            RankInfo rankInfo = rankList[i];
            PlayerPrefs.SetString("rankInfo" + i , rankInfo.playerName);
            PlayerPrefs.SetInt("rankScore" +  i , rankInfo.playerScore);
            PlayerPrefs.SetInt("rankTime" + i , rankInfo.playerTime);
        }
    }

    private void Load()
    {
        int num = PlayerPrefs.GetInt("rankListNum", 0);
        rankList = new List<RankInfo>();
        for (int i = 0;i < num;i++)
        {
            RankInfo info = new RankInfo(PlayerPrefs.GetString("rankInfo" + i),
                                        PlayerPrefs.GetInt("rankScore" + i),
                                         PlayerPrefs.GetInt("rankTime" + i));
            rankList.Add(info);
        }
    }
}


public class Item
{
    public int id;
    public int num;

}

public class Player
{
    public string name;
    public int age;
    public int atk;
    public int def;

    // 存储读取的唯一标识
    private string keyname;


    public List<Item> itemList;

    /// <summary>
    /// 存储数据
    /// </summary>
    public void Save()
    {
        PlayerPrefs.SetString(keyname + "_name", name);
        PlayerPrefs.SetInt(keyname + "_age", age);
        PlayerPrefs.SetInt(keyname + "_atk", atk);
        PlayerPrefs.SetInt(keyname + "_def", def);

        PlayerPrefs.SetInt(keyname + "_ItemNum", itemList.Count);
        // 存储有多少个装备
        for (int i = 0; i < itemList.Count; i++)
        {
            // 存储每一个装备的信息
            PlayerPrefs.SetInt(keyname + "_itemID" + i, itemList[i].id);
            PlayerPrefs.SetInt(keyname + "_itemNum" + i, itemList[i].num);
        }

        PlayerPrefs.Save();
    }


    /// <summary>
    /// 读取数据
    /// </summary>
    public void Load(string keyName)
    {
        name = PlayerPrefs.GetString(keyName + "_name", "未命名");
        age = PlayerPrefs.GetInt(keyName + "_age", 18);
        atk = PlayerPrefs.GetInt(keyName + "_atk", 10);
        def = PlayerPrefs.GetInt(keyName + "_def", 5);

        this.keyname = keyName; 


        // 得到多少装备
        int num = PlayerPrefs.GetInt(keyName + "ItemNum", 0);
        // 初始化容器
        itemList = new List<Item>();
        Item item;
        for (int i = 0; i < num; i++)
        {
            item = new Item();
            item.id = PlayerPrefs.GetInt(keyName + "_itemID" + i);
            item.num = PlayerPrefs.GetInt(keyName + "_itemNum" + i);
            itemList.Add(item);
        }
    }
}


public class P0001_execrcise : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 练习一

        // 现在有一个玩家类 有名字，年龄，攻击力，防御力
        // 封装两个方法一个用来存储数据，一个用来读取数据

        //Player p = new Player();
        //p.Load();
        //print(p.name);
        //print(p.age);
        //print(p.atk);
        //print(p.def);

        //p.name = "唐老师";
        //p.age = 22;
        //p.atk = 40;
        //p.def = 10;
        //// 改了之后存储
        //p.Save();

        #endregion

        #region 练习二

        // 现在有一个装备类 有id，两个成员
        // 上一题玩家类中包含一个List存储了所有的装备信息

        //Player p = new Player();
        //p.Load("Player1");
        //p.Save();

        //Player p2 = new Player();
        //p2.Load("Player2");
        //p2.Save();



        RankListInfo rankListInfo = new RankListInfo();
        print(rankListInfo.rankList.Count);
        for (int i = 0; i < rankListInfo.rankList.Count; i++)
        {
            print("姓名" + rankListInfo.rankList[i].playerName);
            print("分数" + rankListInfo.rankList[i].playerScore);
            print("时间" + rankListInfo.rankList[i].playerTime);
        }


        rankListInfo.Add("Xc", 100, 12);
        rankListInfo.Save();
        


        //// 装备信息
        //print(p.itemList.Count);
        //for (int i = 0; i < p.itemList.Count; i++)
        //{
        //    print("道具id:" + p.itemList[i].id);
        //    print("道具数量:" + p.itemList[i].num);
        //}

        //// 为玩具添加一个装备
        //Item item = new Item();
        //item.id = 1;
        //item.num =1;
        //p.itemList.Add(item);

        //item.id = 2;
        //item.num = 2;
        //p.itemList.Add(item);

        //PlayerPrefs.DeleteAll();

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
