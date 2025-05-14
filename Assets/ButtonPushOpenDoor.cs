using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


//���ư�ť���Ŷ���
public class ButtonPushOpenDoor : MonoBehaviour
{
    public Animator animator;
    public string boolName = "Open";

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => ToggleDoorOpen());
    }

    public void ToggleDoorOpen()
    {
        bool isOpen = animator.GetBool(boolName); 
        animator.SetBool(boolName, !isOpen);
        //���Ŵ򿪲�����Ƶ
        AudioManager.instance.Play("Door");
    }
}
