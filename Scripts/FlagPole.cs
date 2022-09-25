using System.Collections;
using UnityEngine;

public class FlagPole : MonoBehaviour
{
	public Transform flag;
	public Transform poleBottom;
	public Transform castle;
	public float speed = 6f;
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			StartCoroutine(MoveTo(flag, poleBottom.position));
			StartCoroutine(LevelCompleteSequence(other.transform));
		}
	}
	
	private IEnumerator LevelCompleteSequence(Transform player)
	{
		
	}
	
	private IEnumerator MoveTo(Transform subject, Vector3 destination)
	{
		while (Vector3.Distance(subject.position, destination) > 0.125f)
		{
			subject.position = Vector3.MoveTowards(subject.position, destination, speed * Time.deltaTime);
			yield return null;
		}
		
		subject.position = destination;
	}
}
