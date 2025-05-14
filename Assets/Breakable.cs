using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Breakable : MonoBehaviour
{
    //����һ����Ϸ����Ĺ����б�
    public List<GameObject> breakablePieces;
    //��ΪtimeToBreak�Ĺ�������������������Ϊ2�룬float��ʱ��
    public float timeToBreak = 2;
    private float timer = 0;
    public UnityEvent OnBreak;


    void Start()
    {
        //����ÿһ��������Ʒ������Ʒѡ��
        foreach (var item in breakablePieces)
        {
            item.SetActive(false);
        }
            
    }
    //����ÿһ�����鲿�ֵ�ѭ��������ÿһ�����鲿�ֵ�ѭ����
    public void Break()
    {
        //���Ӽ�ʱ���������������ú����ֽ��ʯͷ
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
