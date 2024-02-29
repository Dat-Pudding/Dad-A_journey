using UnityEngine;

public class DialogueBehaviour : MonoBehaviour
{
    [Header("Son Dialogue")]
    public GameObject sonPanel1;
    public GameObject sonPanel2;
    public GameObject sonPanel3;
    public DialogueStarter sonDialogue;

    void Start()
    {
        sonPanel2.SetActive(false);
        sonPanel3.SetActive(false);
    }

    public void ShowSonPanel1()
    {
        sonPanel1.SetActive(true);
        sonPanel2.SetActive(false);
        sonPanel3.SetActive(false);
    }
    public void ShowSonPanel2()
    {
        sonPanel1.SetActive(false);
        sonPanel2.SetActive(true);
        sonPanel3.SetActive(false);
    }
    public void ShowSonPanel3()
    {
        sonPanel1.SetActive(false);
        sonPanel2.SetActive(false);
        sonPanel3.SetActive(true);
    }

    public void CloseAllPanels()
    {
        sonPanel1.SetActive(false);
        sonPanel2.SetActive(false);
        sonPanel3.SetActive(false);
    }
}
