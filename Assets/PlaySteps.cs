using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using static PlaySteps;

public class PlaySteps : MonoBehaviour
{
    //根据指定的索引播放 Timeline 上的特定步骤，并确保每个步骤只播放一次。
    //它通过 PlayableDirector 组件控制 Timeline 的播放，并使用一个 Step 列表来存储步骤的信息。
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

    //应该能够得到目标步与步骤，并得到相应的步骤索引
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
