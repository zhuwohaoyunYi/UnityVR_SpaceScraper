using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

//脚本用来解决抓取物体时手部模型和物体交叉显示，解决办法谁抓谁隐身
public class DisableGrabbingHandModel : MonoBehaviour
{
    public GameObject leftHandModel;
    public GameObject rightHandModel;
    //两个问题：1.如何检测物体何时被抓 2.如何检测哪只手再抓物体
    // Start is called before the first frame update
    void Start()
    {
        //获取XRGrabInteractable，调用grabInteractable
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        //知道对象是否被抓,↓这意味着当这个对象被抓，将触发下面listener括号中任意函数
        //函数HideGrabbingHand和ShowGrabbingHand来达到比较标签隐身对应手的目的
        grabInteractable.selectEntered.AddListener(HideGrabbingHand);
        grabInteractable.selectExited.AddListener(ShowGrabbingHand);

    }

    //现在要知道哪只手再抓，最简单的方法是比较抓取物体的手的标签↓
    //如果左手抓，左手隐身，右手同样
    public void HideGrabbingHand(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.tag == "Left Hand")
        {
            leftHandModel.SetActive(false);
        }
        else if (args.interactableObject.transform.tag == "Right Hand")
        {
            rightHandModel.SetActive(false);
        }
    }

    public void ShowGrabbingHand(SelectExitEventArgs args)
    {
        if (args.interactableObject.transform.tag == "Left Hand")
        {
            leftHandModel.SetActive(true);
        }
        else if (args.interactableObject.transform.tag == "Right Hand")
        {
            rightHandModel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
