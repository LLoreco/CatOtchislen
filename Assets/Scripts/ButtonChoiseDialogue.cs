using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonChoiseDialogue : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject screen;
    [SerializeField] private GameObject correctImage;
    public void CheckButton(bool isTrue)
    {
        OnOffButtons onOff = parent.GetComponent<OnOffButtons>();
        if (isTrue)
        {
            Debug.Log("Верная кнопка");

            if (onOff.itemSprites != null)
            {
                onOff.itemSprites.GetComponent<Button>().enabled = false;
                onOff.DisableClicks();
                //GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>().
            }
            EnableClicks(onOff);
            StartCoroutine(ShowImage());
        }
        else
        {
            Debug.Log("Неверная кнопка");
        }
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
    IEnumerator ShowImage()
    {
        correctImage.SetActive(true);
        yield return new WaitForSeconds(4);
        correctImage.SetActive(false);
        
    }
}
