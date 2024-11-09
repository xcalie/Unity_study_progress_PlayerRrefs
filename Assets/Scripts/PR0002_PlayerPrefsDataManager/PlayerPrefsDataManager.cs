using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// PlayPrefts数据管理类 统一管理数据的存储和读取
/// </summary>
public class PlayerPrefsDataManager
{
    private static PlayerPrefsDataManager instance = new PlayerPrefsDataManager();

    public static PlayerPrefsDataManager Instance
    {
        get
        {
            return instance;
        }
    }

    private PlayerPrefsDataManager()
    {

    }

    /// <summary>
    /// 存储数据
    /// </summary>
    /// <param name="data">数据对象</param>
    /// <param name="keyName">数据对象的唯一key 自己控制</param>
    public void SaveData(object data, string keyName)
    {
        // 通过Type得到传入数据的对象所有的
        // PlayerPrefs的方法进行存储
    }


    /// <summary>
    /// 读取数据
    /// </summary>
    /// <param name="type">想要读取数据的 数据类型</param>
    /// <param name="keyName">数据对象的唯一key 自己控制</param>
    /// <returns></returns>
    public object LoadData(Type type, string keyName)
    {
        // 不用object 对像传入 使用 Type传入
        // 主要目的是节约一行代码
        //假设要读取一个Player类型里的数据 如果是object 必须在外部new一个对象传入
        //现在有type的 只用传入 应该 Type typeof(Player) 然后 在内部动态创建一个对象并返回出来
        //达到了在外部少写一行的目的

        // 根据传入的类型 和 keyName
        // 依据数据的类型 存储数据时key的凭借来进行数据的获取和返回

        return null;
    }
}
