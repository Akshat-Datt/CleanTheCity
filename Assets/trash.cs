using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class trash : MonoBehaviour
{
    // Start is called before the first frame update
    public EventTrigger.TriggerEvent scoreTrigger;
    private void OnCollisionEnter(Collision collision){
        Movement bin = collision.gameObject.GetComponent<Movement>();

        if(bin != null){
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            this.scoreTrigger.Invoke(eventData);
            FindObjectOfType<AudioManager>().Play("Collect");
        }
    }
}
