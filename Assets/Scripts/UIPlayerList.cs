using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;

public class PlayerListUI : MonoBehaviour
{
    public PlayerList playerList; 
    public GameObject playerItemPrefab; 
    public Transform contentParent; 
    public Button toggleButton;
    public RectTransform playerListPanel;


    private bool isOpen = true;

    void Start()
    {
        PopulateList();
        toggleButton.onClick.AddListener(ToggleList);
    }

    void PopulateList()
    {

        foreach (var playerName in playerList.playerNames)
        {
            GameObject item = Instantiate(playerItemPrefab, contentParent);
            TMP_Text textComponent = item.GetComponentInChildren<TMP_Text>();
            textComponent.text = playerName;
        }
    }


    void ToggleList()
    {
        isOpen = !isOpen;
        //float targetScale = isOpen ? 1 : 0;
        //contentParent.DOScaleX(targetScale, 0.3f);
        float targetX = isOpen ? 0 : 410f;
        playerListPanel.DOAnchorPosX(targetX, 0.3f).SetEase(Ease.InOutQuad);
    }
}
