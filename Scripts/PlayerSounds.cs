using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
	//[Header("Som Ambiente")]
	public AudioClip[] swingSounds;

	//[Header("Tipos de chão")]
	public List<AudioClip> grassFS;
	public List<AudioClip> waterFS;
	public List<AudioClip> rockFS;
	
	enum FSMaterial
	{
		Grass, Water, Rock, Empty
	}

	private AudioSource jumpSource,footstepSource;

	void Start()
	{
		jumpSource = GetComponent<AudioSource>();
		footstepSource = GetComponents<AudioSource>()[1];
	}
	
	void PlayerJumpSound()
	{
		AudioClip clip = swingSounds[Random.Range(0, swingSounds.Length)];
		jumpSource.clip = clip;
		jumpSource.Play();
		//Debug.Log(clip.name);
	}

	private FSMaterial SurfaceSelect()
	{
		RaycastHit hit;
		Ray ray = new Ray(transform.position + Vector3.up * 0.5f, -Vector3.up);
		Material surfaceMaterial;

		if(Physics.Raycast(ray, out hit, 1.0f, Physics.AllLayers, QueryTriggerInteraction.Ignore))
		{
			Renderer surfaceRenderer = hit.collider.GetComponentInChildren<Renderer>();
			if (surfaceRenderer)
			{
				surfaceMaterial = surfaceRenderer ? surfaceRenderer.sharedMaterial : null;
				if (surfaceMaterial.name.Contains("Grass"))
				{
					return FSMaterial.Grass;
				}
				else if (surfaceMaterial.name.Contains("Water"))
				{
					return FSMaterial.Water;
				}
				else if (surfaceMaterial.name.Contains("Rock"))
				{
					return FSMaterial.Rock;
				}				
				else
				{
					return FSMaterial.Empty;
				}
			}
		}	
		return FSMaterial.Empty;
	}

	void PlayFootstep()
	{
		AudioClip clip = null;

		FSMaterial surface = SurfaceSelect();

		switch (surface)
		{
			case FSMaterial.Grass:
				clip = grassFS[Random.Range(0, grassFS.Count)];
				break;			
			case FSMaterial.Water:
				clip = waterFS[Random.Range(0, waterFS.Count)];
				break;
			case FSMaterial.Rock:
				clip = rockFS[Random.Range(0, rockFS.Count)];
				break;							
			default:
				break;	
		}

		//Debug.Log(surface);

		if(surface != FSMaterial.Empty)
		{
			footstepSource.clip = clip;
			footstepSource.volume = Random.Range(0.04f, 0.1f);//Range(0.04f, 0.05f);
			footstepSource.pitch = Random.Range(0.8f, 1.2f);
			footstepSource.Play();	
		}
	}
}