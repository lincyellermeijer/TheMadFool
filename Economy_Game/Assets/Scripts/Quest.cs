using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {

    public NPC_Dialog quest;
    public AudioClip collectSound;
    float volume = 0.5f;

    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    void Update()
    {
        if (quest.activateQuest)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
	
	void OnTriggerEnter2D (Collider2D other)
    {
	    if (other.gameObject.CompareTag("Player") && quest.activateQuest)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position, volume);
            Destroy(gameObject);
            quest.hasDoneQuest = true;
        }
	}
}
