using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{

    private void Start()
    {
        //����Ϸ��ʼʱ����������Ͱ�����������������ʯgo��
        GetComponent<TriggerZone>().OnEnterEvent.AddListener(InsideTrash);
    }
    //����ʯgo��������Ͱ���͸ı���ʯ״̬Ϊfalse
    public void InsideTrash(GameObject go)
    {
        go.SetActive(false);
    }
}
