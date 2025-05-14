using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using static PlaySteps;

public class PlaySteps : MonoBehaviour
{
    //����ָ������������ Timeline �ϵ��ض����裬��ȷ��ÿ������ֻ����һ�Ρ�
    //��ͨ�� PlayableDirector ������� Timeline �Ĳ��ţ���ʹ��һ�� Step �б����洢�������Ϣ��
    PlayableDirector director; 
    public List<Step> steps;
    void Start()
    {
        director = GetComponent<PlayableDirector>();
    }

    [System.Serializable]
    public class Step
    {
        public string name;
        public float time;
        public bool hasPlayed = false;
    }

    //Ӧ���ܹ��õ�Ŀ�경�벽�裬���õ���Ӧ�Ĳ�������
    public void PlaystepIndex(int index)
    {
        Step step = steps[index];
        if (!step.hasPlayed)
        {
            step.hasPlayed = true;
            director.Stop();
            director.time = step.time;
            director.Play();
        }
            
    }
}
