using UnityEngine;

public class ManipularVida : MonoBehaviour
{
	VidaPlayer playerVida;
	
	public int quantidade;
	public float damageTime;
	float currentDamageTime;
	
	void Start()
	{
		playerVida = GameObject.FindWithTag("Player").GetComponent<VidaPlayer>();
	}
	
	private void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player")
		{
			currentDamageTime += Time.deltaTime;
			if(currentDamageTime > damageTime)
			{
				playerVida.vida += quantidade;
				currentDamageTime = 0.0f;
			}
		}
	}
}