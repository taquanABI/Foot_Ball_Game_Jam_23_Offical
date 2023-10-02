using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorial : MonoBehaviour
{
    public GameObject nextBtn;
    public bool isDone_Tut;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowNextBtn()
    {
        StartCoroutine(ieShowNextBtn());
    }

    IEnumerator ieShowNextBtn()
    {
        yield return new WaitForSeconds(3f);
        nextBtn.SetActive(true);

    }

    public void DestroySelf()
    {
        gameObject.SetActive(false);
    }
    
    public void DestroySelf_OK()
    {
        isDone_Tut = true;
        gameObject.SetActive(false);
    }


}
