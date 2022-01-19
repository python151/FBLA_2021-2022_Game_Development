using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    public static List<Interaction> canInteractWith;

    public GameObject _InteractionsTextMeshProGameObject;
    private TMP_Text _interactionsTextMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        canInteractWith = new List<Interaction>();
        _interactionsTextMeshPro = _InteractionsTextMeshProGameObject.GetComponent<TMP_Text>();
        InvokeRepeating(nameof(UpdateInteractionsUI), .05f, .05f);
    }

    void UpdateInteractionsUI()
    {
        string newText = "";
        foreach (var interaction in canInteractWith)
        {
            if (interaction.showPrompt)
                newText += $"Press {interaction.initiator} to interact.\n";
        }

        _interactionsTextMeshPro.text = newText;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var possibleInteraction in canInteractWith)
        {
            if (Input.GetKeyDown(possibleInteraction.initiator)) possibleInteraction.action();
        }
    }
}
