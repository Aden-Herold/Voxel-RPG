using UnityEngine;
using System.Collections;

public class DaynightController : MonoBehaviour {

    public Light sun;
    public float timeInDay = 120f, currentTime = 0f;

	public Material skyDay;
	public Material skyNight;

    private GameObject sunPOS, player;
    public bool night = true;
    private Vector3 cameraPos;

	private bool skyboxNight = false;

    private float intesity, IntensityMultiplier, sunPosX, sunPosY, temp;
    
	void Start () {
        sunPOS = GameObject.Find("Directional Light");
        player = GameObject.Find("Main Camera");

        sunPosX = 0f; sunPosY = 0f;
        sun = sunPOS.GetComponent<Light>();

        sunPOS.transform.Translate(new Vector3(sunPosX, sunPosY, cameraPos.z));
	    sun.intensity = intesity;
	}
	
	void Update () {
        UpdateRotation();
        IntensityModifier();
        UpdateLocation();

        currentTime += (Time.deltaTime / timeInDay) * 2f;

        if (currentTime >= 1) {
            currentTime = 0;
            sunPosX = 0f; sunPosY = 0f;

            if (night)
            {
                sun.color = Color.white;

				if (!skyboxNight) {
					RenderSettings.skybox = skyNight;
					skyboxNight = true;
				}

            }
            else {
                sun.color = new Color(0.74F, 0.906f, 1, 1);//Color.blue;

				if (skyboxNight) {
					RenderSettings.skybox = skyDay;
					skyboxNight = false;
				}
            }

            night = !night;
        }
    }

    private void UpdateRotation() {
        //Transform anchor = player.transform;
        //anchor.position = new Vector3(anchor.position.x, 0f, 0f);
        sun.transform.LookAt(player.transform);          //  roRotate(new Vector3(0f, 0f, 0f));      //RotateAround(player.transform.position, sunPOS.transform.position, 20 * Time.deltaTime);      //localRotation = Quaternion.Euler((currentTime * 360) - 90, 180, 0f);
    }

    private void IntensityModifier() {

        IntensityMultiplier = 4;

        if (!night) {
			IntensityMultiplier = IntensityMultiplier / 6;
		}

        if (currentTime > 0.5)
        {
            temp = 1.5f - currentTime;
        }
        else
        {
            temp = .5f + currentTime;
        }

        temp = temp / 5;

        IntensityMultiplier = IntensityMultiplier * temp;

        sun.intensity = IntensityMultiplier;
    }

    private void UpdateLocation() {
        GetCameraLocation();

        sunPosX = (300 - (600f*currentTime));

        temp = (float)((sunPosX*sunPosX)/600);
        sunPosY = 150 - ((sunPosX * sunPosX) / 600);

        if (player.transform.position.y > 0) {
            sunPosY += player.transform.position.y;
        }

        sunPOS.transform.position = new Vector3(sunPosX + player.transform.position.x, sunPosY, player.transform.position.z);
    }

    private void GetCameraLocation() {
        cameraPos = player.transform.position;        
    }
}