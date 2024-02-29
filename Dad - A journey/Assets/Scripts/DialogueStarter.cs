using UnityEngine;

public class DialogueStarter : MonoBehaviour
{
    public PlayerMovement_SideScroll playerMovement;
    public DialogueBehaviour dialogueLogic;
    public int panelCounter;

    void Start()
    {
        panelCounter = 0;
    }

    private void Awake()
    {
        dialogueLogic.ShowSonPanel1();

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerMovement.enabled == false)
        {
            ++panelCounter;
        }
        switch (panelCounter)
        {
            case 1:
                playerMovement.enabled = false;
                dialogueLogic.ShowSonPanel2();
                return;

            case 2:
                dialogueLogic.ShowSonPanel3();
                return;

            case 3:
                dialogueLogic.CloseAllPanels();
                playerMovement.enabled = true;
                return;

            case 4:
                panelCounter = 3;
                return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "EventPoint")
        {
            panelCounter++;
        }
    }
}
