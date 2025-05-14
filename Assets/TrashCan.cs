using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{

    private void Start()
    {
        //在游戏开始时，监听垃圾桶里面的垃圾（就是陨石go）
        GetComponent<TriggerZone>().OnEnterEvent.AddListener(InsideTrash);
    }
    //把陨石go丢进垃圾桶，就改变陨石状态为false
    public void InsideTrash(GameObject go)
    {
        go.SetActive(false);
    }
}
