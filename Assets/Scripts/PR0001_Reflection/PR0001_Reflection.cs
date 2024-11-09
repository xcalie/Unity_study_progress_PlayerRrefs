using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Father
{

}

public class Son : Father
{

}



public class PR0001_Reflection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 三个b

        // Type 获取 类的所有字段信息
        // Assembly 获取 程序集
        // Activator 快速建立对象

        #endregion

        #region 判断哪个类型可以分配空间

        // 父类装子类
        // 是否可以从某一个对象的类型 为自己分配空间

        Type fatherType = typeof(Father);
        Type sonType = typeof(Son);

        // 调用这个方法查看是否有父子关系 进行里式替换原则
        if (fatherType.IsAssignableFrom(sonType))
        {
            print("可以装");
            Father f = Activator.CreateInstance(sonType) as Father;
        }
        else
        {
            print("不能装");
        }

        #endregion

        #region 通过反射获取泛型类型


        List<string> list = new List<string>();
        Type listType = list.GetType();

        Type[] types = listType.GetGenericArguments();
        print(types[0]);

        Dictionary<string, float> dic = new Dictionary<string, float>();
        Type dicType = dic.GetType();
        types = dicType.GetGenericArguments();
        print(types[0]);
        print(types[1]);

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
