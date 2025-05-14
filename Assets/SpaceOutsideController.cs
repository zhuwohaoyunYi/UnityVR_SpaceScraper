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

    // Update() ������ÿһ֡���ã����ڸ��¶����λ��
    void Update()
    {
        // ���� lever ��ֵ����ǰ���ٶȣ���� lever ֵΪ�棬��ʹ�� forwardSpeed������Ϊ 0
        // ���� lever ��ֵ�� knob ��ֵ��������ٶȣ�knob.value��0-1�仯����ֵ��-1��1��Ӧ�仯
        float forwardVelocity = forwardSpeed * (lever.value ? 1 : 0); 
        float sideVelocity = sideSpeed * (lever.value ? 1 : 0) * Mathf.Lerp(-1, 1, knob.value);

        // ����һ���ٶ����������� x ����Ϊ�����ٶȣ�z ����Ϊǰ���ٶȣ�y ����Ϊ 0�����ı�߶ȣ�
        // ����̫�������λ�ã����ٶ��������� Time.deltaTime �Կ���֡�ʵı仯
        Vector3 velocity = new Vector3(sideVelocity, 0, forwardVelocity); 
        transform.position += velocity * Time.deltaTime;

        //�����˱��ı�ʱ��ִ�в��ţ�ͬʱ��ֻ֤��һ��
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
