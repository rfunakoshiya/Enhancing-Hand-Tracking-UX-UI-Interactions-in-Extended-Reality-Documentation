using UnityEngine;
using System;
using DataClasses;
using System.Collections.Generic;

public class DataCollector : MonoBehaviour
{
    
    
    private bool _recordData = false;
    [SerializeField] private InteractionData _interactionData;
    
    [SerializeField] private AudioSource _startCollectingSound;
    [SerializeField] private AudioSource _stopCollectingSound;
    
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            _recordData = true;
            _interactionData.startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _startCollectingSound.Play();
        }

        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            _recordData = false;
            DataManager.Instance.SaveData(_interactionData);
            _stopCollectingSound.Play();
        }
    }

    public void RecordMoveInteractable()
    {
        if (!_recordData) return;
        
        Interaction interaction = new Interaction("Move");
        
        _interactionData.interactions.Add(interaction);
        _interactionData.moveInteractions.Add(interaction);
        
        _interactionData.moveCount++;
        
    }
    public void RecordResizeInteractable()
    {
        if (!_recordData) return;
        
        Interaction interaction = new Interaction("Resize");
        
        _interactionData.interactions.Add(interaction);
        _interactionData.resizeInteractions.Add(interaction);
        
        _interactionData.resizeCount++;
    }

}
