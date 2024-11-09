using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P0001_Start : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region PlayerRrefs

        // unity用于储存读取玩家数据的公共类

        #endregion

        #region 存储

        // PlayerRrefs 的数据存储 类似于键值对
        // 一共3种方法
        // int float string 
        // 键: string
        // 值：int float string 对应三种API

        PlayerPrefs.SetInt("myAge", 18);
        PlayerPrefs.SetFloat("myHeight", 177.5f);
        PlayerPrefs.SetString("myName", "xc");

        // 直接调用set相关方法 只会存到内存中 
        // 当游戏结束中 unity 会自动把数据存到硬盘中
        // 如果游戏不是正常结束的 而是崩溃 数据不会存到硬盘中

        // 只要调用这个方法 就会马上存到硬盘中
        PlayerPrefs.Save();


        // PlayerPrefs 有局限性 只能存3种类型
        // 想要存别的只能降低精度，或者上升精度来存
        bool sex = true;
        PlayerPrefs.SetInt("sex", sex ? 1 : 0);

        // 如果使用不同类型同一键名存储 会覆盖
        PlayerPrefs.SetFloat("myAge", 20.0f);



        #endregion

        #region 读取

        // 运行的时候 只要 set 了对应键值对
        // 即使没有存储到本地
        // 也能够读出信息

        // int 
        int age = PlayerPrefs.GetInt("myAge");
        print(age);
        // 如果找不到对应值 会返回类型默认值 不设置为默认的值，设置了为第二个值
        age = PlayerPrefs.GetInt("myAge", 100);

        // float
        float height = PlayerPrefs.GetFloat("myHeight", 1000.0f);
        print(height);

        // string
        string name = PlayerPrefs.GetString("myName", "Sexy");
        print(name);

        // 第二个参数 默认值 对于我们的作用
        // 就是 在得到没有的数据的时候 就可以用它来进行基础的数据的初始化

        // 判断数据是否存在
        if (PlayerPrefs.HasKey("myName"))
        {
            print("存在myName的键值对");

        }

        #endregion

        #region 删除数据

        // 删除指定键值对
        PlayerPrefs.DeleteKey("myAge");
        // 删除所有的存储的性格
        PlayerPrefs.DeleteAll();

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
