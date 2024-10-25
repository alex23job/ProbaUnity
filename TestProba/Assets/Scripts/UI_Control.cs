<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Control : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private Text txtInfo;

    [SerializeField] private Text txtTime;
    [SerializeField] private Text txtHP;
    [SerializeField] private Image imgHP;

    [SerializeField] private Button[] itemButtons;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject inventoryPanel;

    [SerializeField] private GameObject finishPanel;
    [SerializeField] private GameObject lossPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) LoadMenuScene();
        if (Input.GetKeyDown(KeyCode.R)) Restart();
        if (Input.GetKeyDown(KeyCode.I)) ViewInventory();
    }

    public void ViewInfo(string str, bool isView = true)
    {
        txtInfo.text = str;
        infoPanel.SetActive(isView);
    }

    public void ViewInventory()
    {
        CollectedItem[] items = inventory.GetItems();
        //print($"items Count={items.Length}");
        for (int i = 0; i < itemButtons.Length && i < items.Length; i++) 
        {
            itemButtons[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].ItemSprite;
            itemButtons[i].transform.GetChild(0).GetComponent<Image>().color = Color.white;
            itemButtons[i].transform.GetChild(1).GetComponent<Text>().text = $"{items[i].Count}";
            itemButtons[i].transform.GetChild(2).GetComponent<Text>().text = items[i].ItemName;
            //print($"i={i} n={items[i].Count} nm={items[i].ItemName}");
        }
        inventoryPanel.SetActive(true);
    }

    public void ViewFinishLevel()
    {
        finishPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ViewLossPanel()
    {
        lossPanel.SetActive(true);
    }

    public void ViewHP(int hp, int maxHp)
    {
        txtHP.text = $"HP:{hp}";
        imgHP.fillAmount = (float)hp / (float)maxHp;
    }

    public void ViewTime(int second)
    {
        txtTime.text = $"{second / 60:D02}:{second % 60:D02}";
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Control : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private Text txtInfo;

    [SerializeField] private Text txtTime;
    [SerializeField] private Text txtHP;
    [SerializeField] private Image imgHP;

    [SerializeField] private Button[] itemButtons;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject inventoryPanel;

    [SerializeField] private GameObject finishPanel;
    [SerializeField] private GameObject lossPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) LoadMenuScene();
        if (Input.GetKeyDown(KeyCode.R)) Restart();
        if (Input.GetKeyDown(KeyCode.I)) ViewInventory();
    }

    public void ViewInfo(string str, bool isView = true)
    {
        txtInfo.text = str;
        infoPanel.SetActive(isView);
    }

    public void ViewInventory()
    {
        CollectedItem[] items = inventory.GetItems();
        //print($"items Count={items.Length}");
        for (int i = 0; i < itemButtons.Length && i < items.Length; i++) 
        {
            itemButtons[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].ItemSprite;
            itemButtons[i].transform.GetChild(0).GetComponent<Image>().color = Color.white;
            itemButtons[i].transform.GetChild(1).GetComponent<Text>().text = $"{items[i].Count}";
            itemButtons[i].transform.GetChild(2).GetComponent<Text>().text = items[i].ItemName;
            //print($"i={i} n={items[i].Count} nm={items[i].ItemName}");
        }
        inventoryPanel.SetActive(true);
    }

    public void ViewFinishLevel()
    {
        finishPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ViewLossPanel()
    {
        lossPanel.SetActive(true);
    }

    public void ViewHP(int hp, int maxHp)
    {
        txtHP.text = $"HP:{hp}";
        imgHP.fillAmount = (float)hp / (float)maxHp;
    }

    public void ViewTime(int second)
    {
        txtTime.text = $"{second / 60:D02}:{second % 60:D02}";
    }
}
>>>>>>> c370533cebd4cd3cbf580a37a8dd0a4fa6e374fd
