using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChoiseDialogue : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject screen;
    public void CheckButton(bool isTrue)
    {
        OnOffButtons onOff = parent.GetComponent<OnOffButtons>();
        if (isTrue)
        {
            Debug.Log("Верная кнопка");

            if (onOff.itemSprites != null)
            {
                onOff.itemSprites.GetComponent<Button>().enabled = false;
            }
        }
        else
        {
            Debug.Log("Неверная кнопка");
        }
        EnableClicks(onOff);
        screen.SetActive(false);
    }
    private void EnableClicks(OnOffButtons onOff)
    {
        foreach(var item in onOff.enabledClicks)
        {
            item.GetComponent<Button>().enabled = true;
            item.GetComponent<Animator>().enabled = true;
        }
    }
}
