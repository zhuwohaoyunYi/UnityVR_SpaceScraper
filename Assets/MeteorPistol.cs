using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MeteorPistol : MonoBehaviour
{
    //我们需要使用光线投射来触发break函数。
    //粒子
    public ParticleSystem particles;
    //图层蒙版用于光线投射
    public LayerMask layerMask; 
    //光纤投射起点
    public Transform shootSource;
    //光纤投射最大距离
    public float distance = 10;

    private bool rayActivate = false;

    // Start is called before the first frame update
    void Start()
    {
        //监听抓取发射，连接到两个方法
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>(); 
        grabInteractable.activated.AddListener(x => StartShoot()); 
        grabInteractable.deactivated.AddListener(x => StopShoot());
    }
    //为了检查光线投射时，玩家正在激活粒子系统。
    public void StartShoot()
    {
        particles.Play();
        rayActivate = true;
    }

    public void StopShoot()
    {
        //开始射击 播放音频
        AudioManager.instance.Play("Pistol");
        //当停止射击时，停止粒子播放并清除所有粒子
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        rayActivate = false;
    }

    void Update()
    {
        //停止射击 更新停止音频
        AudioManager.instance.Stop("Pistol");
        //如果射线启动，则检测是否与物体相交
        if (rayActivate)
        {
            Raycastcheck();
        }
    }

    //检测从某个点出发的射线是否与场景中的物体相交
    void Raycastcheck()
    {
        RaycastHit hit;//存储射线检测的结果
        //Physics.Raycast射线检测方法，用于检测从指定起点出发的射线是否与场景中的物体相交
        //（起点，方向，存储相交信息，最大检测距离，层掩码，用于指定射线检测时应该考虑哪些层的物体）
        bool hasHit = Physics.Raycast(shootSource.position, shootSource.forward,out hit, distance, layerMask);
        if (hasHit)
        {
            //如果射线与物体相交（true）则发消息调用该物体上的 Break 方法
            hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
        }
    }
}
