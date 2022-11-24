using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject achievementPanel;
    [SerializeField] private GameObject questJournalPanel;

    public void ToggleUI(GameObject go)
    {
        go.SetActive(!go.activeSelf);
    }
}
