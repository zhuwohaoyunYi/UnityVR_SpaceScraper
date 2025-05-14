using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

//�ű��������ץȡ����ʱ�ֲ�ģ�ͺ����彻����ʾ������취˭ץ˭����
public class DisableGrabbingHandModel : MonoBehaviour
{
    public GameObject leftHandModel;
    public GameObject rightHandModel;
    //�������⣺1.��μ�������ʱ��ץ 2.��μ����ֻ����ץ����
    // Start is called before the first frame update
    void Start()
    {
        //��ȡXRGrabInteractable������grabInteractable
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        //֪�������Ƿ�ץ,������ζ�ŵ��������ץ������������listener���������⺯��
        //����HideGrabbingHand��ShowGrabbingHand���ﵽ�Ƚϱ�ǩ�����Ӧ�ֵ�Ŀ��
        grabInteractable.selectEntered.AddListener(HideGrabbingHand);
        grabInteractable.selectExited.AddListener(ShowGrabbingHand);

    }

    //����Ҫ֪����ֻ����ץ����򵥵ķ����ǱȽ�ץȡ������ֵı�ǩ��
    //�������ץ��������������ͬ��
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
