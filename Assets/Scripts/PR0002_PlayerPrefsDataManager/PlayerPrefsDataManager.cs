using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

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

        #region 得到所有字段

        Type dataType = data.GetType();
        // 得到所有字段
        FieldInfo[] infos = dataType.GetFields();
        //for (int i = 0; i < infos.Length; i++)
        //{
        //    Debug.Log(infos[i]);
        //}

        #endregion

        #region 自己定义一个key

        //存储通过PlayerPrefs来进行存储
        //保证key的唯一性 需要自己定key的规则

        // keyName_数据类型_字段类型_字段名

        #endregion

        #region 遍历字段进行数据存储

        string saveKeyName = "";
        FieldInfo info;
        for (int i = 0; i < infos.Length; i++)
        {
            //对每一个字段进行存储
            // 得到具体的字段信息
            info = infos[i];
            // 字段的类型info.FieldType.Name
            // 字段的名字info.Name

            // 根据拼接规则进行key的生成
            // Player1_PlayerInfo_Int32_age
            // keyName_数据类型_字段类型_字段名
            saveKeyName = keyName + "_" + dataType.Name + "_" + info.FieldType.Name + "_" + info.Name;

            // 得到key之后按照规则通过PlayerPrefs来存储
            // 获取值info.GetValue(data)
            SaveValue(info.GetValue(data), saveKeyName);
            
        }

        #endregion
    }


    private void SaveValue(object value, string keyName)
    {
        // 直接通过PlayerPrefs进行存储
        // 只支持3种类型 int float string
        Type fieldType = value.GetType();

        // 类型判断
        if (fieldType == typeof(int))
        {
            PlayerPrefs.SetInt(keyName, (int)value);
        }
        else if (fieldType == typeof(float))
        {
            PlayerPrefs.SetFloat(keyName, (float)value);
        }
        else if (fieldType == typeof(string))
        {
            PlayerPrefs.SetString(keyName, (string)value);
        }
        else if (fieldType == typeof(bool))
        {
            PlayerPrefs.SetInt(keyName, (bool)value? 1 : 0);
        }
        // 如何判断 泛型的类型
        // 通过反射 判断父子关系
        // 判断字段是不是List的子类
        else if (typeof(IList).IsAssignableFrom(fieldType))
        {
            // 父类装子类
            IList list = value as IList;
            // 先存储数量
            PlayerPrefs.SetInt(keyName, list.Count);
            foreach ( object obj in list )
            {
                // 存储具体的值

            }
        }
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

        Type[] types = type.GetInterfaces();


        return null;
    }
}
