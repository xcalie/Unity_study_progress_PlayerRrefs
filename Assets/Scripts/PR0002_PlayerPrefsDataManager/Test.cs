using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    public int age = 10;
    public string name = "未命名";
    public float height = 177.5f;
    public bool sex = true;


}

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerInfo info = new PlayerInfo();
        PlayerPrefsDataManager.Instance.SaveData(info, "Player1");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
