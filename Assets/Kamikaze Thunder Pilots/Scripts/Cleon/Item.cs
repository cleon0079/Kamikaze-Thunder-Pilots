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
				// ToDo Show text on the item
				if(gameManager.canOpenDoor)
				{
					// ToDo Shows open door text
				}
				else
				{
					// ToDo Shows cant open door text
				}

				if(Input.GetKeyDown(KeyCode.F))
				{
					if(type == Type.BulletTime)
					{
						gameManager.canBulletTime = true;
						// ToDo Show item description
						// ToDo Show bullet time cool down UI
						Destroy(gameObject);
					}

					if(type == Type.Key)
					{
						gameManager.canOpenDoor = true;
						// ToDo Show item description
						Destroy(gameObject);
					}

					if(gameManager.canOpenDoor)
					{
						// ToDo Play open door anim
					}
				}
			}
		}

		public enum Type
		{
			BulletTime,
			Key,
			Door
		}
	}
}