using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class SpaceOutsideController : MonoBehaviour
{
    public XRLever lever;
    public XRKnob knob;
    public float forwardSpeed;
    public float sideSpeed;

    private bool wasOn;
    
    void Start()
    {
        
    }

    // Update() 方法在每一帧调用，用于更新对象的位置
    void Update()
    {
        // 根据 lever 的值计算前进速度，如果 lever 值为真，则使用 forwardSpeed，否则为 0
        // 根据 lever 的值和 knob 的值计算侧向速度，knob.value在0-1变化反馈值在-1到1对应变化
        float forwardVelocity = forwardSpeed * (lever.value ? 1 : 0); 
        float sideVelocity = sideSpeed * (lever.value ? 1 : 0) * Mathf.Lerp(-1, 1, knob.value);

        // 创建一个速度向量，其中 x 分量为侧向速度，z 分量为前进速度，y 分量为 0（不改变高度）
        // 更新太空物体的位置，将速度向量乘以 Time.deltaTime 以考虑帧率的变化
        Vector3 velocity = new Vector3(sideVelocity, 0, forwardVelocity); 
        transform.position += velocity * Time.deltaTime;

        //当拉杆被改变时，执行播放，同时保证只做一次
        if (lever.value != wasOn)
        {
            if (lever.value)
            {
                AudioManager.instance.Play("Engine");
            }
            else
            {
                AudioManager.instance.Stop("Engine");
            }
        }
        wasOn = lever.value;
    }
}
