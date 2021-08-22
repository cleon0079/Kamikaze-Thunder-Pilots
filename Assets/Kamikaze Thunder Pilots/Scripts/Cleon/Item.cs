using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Cleon
{
	public class Item : MonoBehaviour
	{
		private GameManager gameManager;
		
		[SerializeField] private Type type;

		private void Start()
		{
			gameManager = FindObjectOfType<GameManager>();
		}

		private void OnTriggerStay2D(Collider2D _collider2D)
		{
			if(_collider2D.CompareTag("Player"))
			{
				switch(type)
				{
					// Pick up the bullet time item and shows the UI
					case Type.BulletTime:
						gameManager.canvasOnObject.transform.position = transform.position + new Vector3(0, .8f, 0);
						gameManager.canvasOnObjectText.text = "Press 'F' to pick up";
						gameManager.canvasOnObject.SetActive(true);
						if(Input.GetKeyDown(KeyCode.F))
						{
							gameManager.canBulletTime = true;
							gameManager.canvasItemDisplay.SetActive(true);
							gameManager.bulletTimeCanvasImage.SetActive(true);
							gameManager.canvasItemImage.sprite = gameManager.bulletTimeIcon;
							gameManager.canvasItemName.text = gameManager.bulletTimeName;
							gameManager.canvasItemDescription.text = gameManager.bulletTimeDescription;
							gameManager.PickUpSFX();
							Time.timeScale = 0;
							Destroy(gameObject);
						}
						break;
					// Pick up the key item and shows the UI
					case Type.Key:
						gameManager.canvasOnObject.transform.position = transform.position + new Vector3(0, .8f, 0);
						gameManager.canvasOnObjectText.text = "Press 'F' to pick up";
						gameManager.canvasOnObject.SetActive(true);
						if(Input.GetKeyDown(KeyCode.F))
						{
							gameManager.canOpenDoor = true;						
							gameManager.canvasItemDisplay.SetActive(true);
							gameManager.keyCanvasImage.SetActive(true);
							gameManager.canvasItemImage.sprite = gameManager.keyIcon;
							gameManager.canvasItemName.text = gameManager.keyName;
							gameManager.canvasItemDescription.text = gameManager.keyDescription;
							gameManager.PickUpSFX();
							Time.timeScale = 0;
							Destroy(gameObject);
						}
						break;
					case Type.Door:
						// If we got the key then we can open the door, if we dont then shows the UI
						gameManager.canvasOnObject.transform.position = transform.position + new Vector3(0, .8f, 0);
						gameManager.canvasOnObject.SetActive(true);
						if(gameManager.canOpenDoor)
						{
							gameManager.canvasOnObjectText.text = "Press 'F' to open door";
							if(Input.GetKeyDown(KeyCode.F))
							{
								SpriteRenderer doorRenderer = GetComponent<SpriteRenderer>();
								doorRenderer.sprite = gameManager.openDoorSprite;
								gameManager.PickUpSFX();
								Invoke("End", 0.5f);
							}
						}
						else
						{
							gameManager.canvasOnObjectText.text = "Find the key to open door!";
						}
						break;
					default:
						break;
				}
			}
		}

		/// <summary>
		/// Calls the function from the Game manager.
		/// </summary>
		private void End()
		{
			gameManager.EndGame();
		}

		/// <summary>
		/// Type of the item
		/// </summary>
		public enum Type
		{
			BulletTime,
			Key,
			Door
		}
	}
}