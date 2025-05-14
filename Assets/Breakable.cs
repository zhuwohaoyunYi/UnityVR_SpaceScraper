using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Breakable : MonoBehaviour
{
    //创建一个游戏对象的公共列表
    public List<GameObject> breakablePieces;
    //名为timeToBreak的公共浮动，并将其设置为2秒，float计时器
    public float timeToBreak = 2;
    private float timer = 0;
    public UnityEvent OnBreak;


    void Start()
    {
        //对于每一件易碎物品，做物品选择。
        foreach (var item in breakablePieces)
        {
            item.SetActive(false);
        }
            
    }
    //对于每一个易碎部分的循环，对于每一个易碎部分的循环，
    public void Break()
    {
        //增加计时器，如果大于则调用函数分解大石头
        timer += Time.deltaTime;
        if (timer > timeToBreak)
        {
            foreach (var item in breakablePieces)
            {
                item.SetActive(true);
                item.transform.parent = null;
            }
            OnBreak.Invoke();
            gameObject.SetActive(false);
        }
    }
}
