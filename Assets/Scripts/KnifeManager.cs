
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeManager : MonoBehaviour
{   [SerializeField] private List<GameObject> KnifeIconList = new List<GameObject>();
    [SerializeField] private List<GameObject> KnifeList = new List<GameObject>();
    [SerializeField] private GameObject KnifePrefab;

    [SerializeField] public  int KnifeCount;
    [SerializeField] private GameObject KnifeIconPrefab;

    [SerializeField] private Vector2 KnifeIconPosition;
    [SerializeField] private Color ActiveColor;
    [SerializeField] private Color DisabledColor;
    public GameObject WinPanel;
    private int KnifeIndex = 0;
    private void Start(){
        CreateKnifes();
        CreateKnifeIcons();
    }
    public void Update(){
        int childCount = PlayerPrefs.GetInt("Child");
        if(childCount == KnifeCount){
            WinPanel.SetActive(true);
            PlayerPrefs.SetInt("Child",0);
            PlayerPrefs.Save();
        }
    }
    private void CreateKnifes(){
        for (int i = 0; i < KnifeCount; i++)
        {   
            GameObject newKnife = Instantiate(KnifePrefab,transform.position,Quaternion.identity);
            newKnife.SetActive(false);
            KnifeList.Add(newKnife);
        }
        KnifeList[0].SetActive(true);
    }

    private void CreateKnifeIcons(){
        for (int i = 0; i < KnifeCount; i++)
        {
            GameObject newKnifeIcon = Instantiate(KnifeIconPrefab,KnifeIconPosition,KnifeIconPrefab.transform.rotation);
            newKnifeIcon.GetComponent<SpriteRenderer>().color = ActiveColor;
            KnifeIconPosition.y += 0.5f;
            KnifeIconList.Add(newKnifeIcon);
        }
    }
    public void SetDisableKnifeIconColor(){
        KnifeIconList[(KnifeIconList.Count -1) - KnifeIndex].GetComponent<SpriteRenderer>().color = DisabledColor;
       
    }
    public void SetActiveKnife(){
        if(KnifeIndex < KnifeCount -1){
            KnifeIndex++;
            KnifeList[KnifeIndex].SetActive(true);
        }
    }
    public void TekrarOyna(){
        SceneManager.LoadScene(0);
    }
}
