using UnityEngine;
using System.Collections;

public class carLights : MonoBehaviour {

	public Renderer brakeLights1, brakeLights2;

	public Material backLightOFF;
	public Material backLightON;

	public Renderer headlights, headlights1, headlights2, headlights3;

	public Material headlightsOFF;
	public Material headlightsON;

	public Light headlightLeft;
	public Light headlightRight;

	public Renderer frontTurnSignalRight, frontTurnSignalLeft;
	public Renderer rearTurnSignalLeft, rearTurnSignalRight;

	public Material turnSignalON;
	public Material turnSignalOFF;

	private bool rightSignalON = false;
	private bool leftSignalON = false;




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//braking
		if (Input.GetKey(KeyCode.S))
		{
			brakeLights1.material = backLightON;
			brakeLights2.material = backLightON;
		}
		//not braking
		else
		{
			brakeLights1.material = backLightOFF;
			brakeLights2.material = backLightOFF;
		}


		//headlights on/off
		if (Input.GetKeyDown(KeyCode.L))
		{
				headlights.material = headlightsON;
				headlights1.material = headlightsON;
				headlights2.material = headlightsON;
				headlights3.material = headlightsON;

				headlightLeft.intensity = 8f;
				headlightRight.intensity = 8f;
		}	
		else if(Input.GetKeyDown(KeyCode.K))
			{
				headlights.material = headlightsOFF;
				headlights1.material = headlightsOFF;
				headlights2.material = headlightsOFF;
				headlights3.material = headlightsOFF;

				headlightLeft.intensity = 0f;
				headlightRight.intensity = 0f;
			}


		//turn signal left/right
		if (Input.GetKey(KeyCode.Q))
		{
			frontTurnSignalLeft.material = turnSignalON;
			rearTurnSignalLeft.material = turnSignalON;

			leftSignalON = true;
			rightSignalON = false;

			frontTurnSignalRight.material = turnSignalOFF;
			rearTurnSignalRight.material = turnSignalOFF;
		}	

		else if(Input.GetKey(KeyCode.E))
		{
			frontTurnSignalRight.material = turnSignalON;
			rearTurnSignalRight.material = turnSignalON;

			rightSignalON = true;
			leftSignalON = false;

			frontTurnSignalLeft.material = turnSignalOFF;
			rearTurnSignalLeft.material = turnSignalOFF;
		}

		else
		{
			frontTurnSignalRight.material = turnSignalOFF;
			rearTurnSignalRight.material = turnSignalOFF;
			frontTurnSignalLeft.material = turnSignalOFF;
			rearTurnSignalLeft.material = turnSignalOFF;

			leftSignalON = false;
			rightSignalON = false;
		}

		//blinking turn signal
		if(leftSignalON)
		{
			float floor = 0f;
			float ceiling = 30f;
			float emission = floor + Mathf.PingPong(Time.time*2f, ceiling - floor);
			frontTurnSignalLeft.material.SetColor("_EmissionColor", new Color(255f,248f,0f) * emission);
			rearTurnSignalLeft.material.SetColor("_EmissionColor", new Color(255f,248f,0f)*emission);
		}

		if(rightSignalON)
		{
			float floor = 0f;
			float ceiling = 30f;
			float emission = floor + Mathf.PingPong(Time.time*2f, ceiling - floor);
			frontTurnSignalRight.material.SetColor("_EmissionColor", new Color(255f,248f,0f)*emission);
			rearTurnSignalRight.material.SetColor("_EmissionColor", new Color(255f,248f,0f)*emission);
		}
		
	
	}
}
