using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MeteorPistol : MonoBehaviour
{
    //������Ҫʹ�ù���Ͷ��������break������
    //����
    public ParticleSystem particles;
    //ͼ���ɰ����ڹ���Ͷ��
    public LayerMask layerMask; 
    //����Ͷ�����
    public Transform shootSource;
    //����Ͷ��������
    public float distance = 10;

    private bool rayActivate = false;

    // Start is called before the first frame update
    void Start()
    {
        //����ץȡ���䣬���ӵ���������
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>(); 
        grabInteractable.activated.AddListener(x => StartShoot()); 
        grabInteractable.deactivated.AddListener(x => StopShoot());
    }
    //Ϊ�˼�����Ͷ��ʱ��������ڼ�������ϵͳ��
    public void StartShoot()
    {
        particles.Play();
        rayActivate = true;
    }

    public void StopShoot()
    {
        //��ʼ��� ������Ƶ
        AudioManager.instance.Play("Pistol");
        //��ֹͣ���ʱ��ֹͣ���Ӳ��Ų������������
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        rayActivate = false;
    }

    void Update()
    {
        //ֹͣ��� ����ֹͣ��Ƶ
        AudioManager.instance.Stop("Pistol");
        //������������������Ƿ��������ཻ
        if (rayActivate)
        {
            Raycastcheck();
        }
    }

    //����ĳ��������������Ƿ��볡���е������ཻ
    void Raycastcheck()
    {
        RaycastHit hit;//�洢���߼��Ľ��
        //Physics.Raycast���߼�ⷽ�������ڼ���ָ���������������Ƿ��볡���е������ཻ
        //����㣬���򣬴洢�ཻ��Ϣ���������룬�����룬����ָ�����߼��ʱӦ�ÿ�����Щ������壩
        bool hasHit = Physics.Raycast(shootSource.position, shootSource.forward,out hit, distance, layerMask);
        if (hasHit)
        {
            //��������������ཻ��true������Ϣ���ø������ϵ� Break ����
            hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
        }
    }
}
