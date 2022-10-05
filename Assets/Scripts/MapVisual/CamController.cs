using UnityEngine;
using System.Collections;
using System;

public class CamController : MonoBehaviour
{
	public static bool IsControl = true;


	public float moveSpeed = 3f;

	public float posZSpeed = 3f;



	public float minDistance = -1;
	public float maxDistance = -30;

	private float distance = -20;

	public Vector2 MaxX;
	public Vector2 MaxY;
	/// <summary>

	/// </summary>
	public float resolutionX = 1920;
	/// <summary>

	/// </summary>
	public float resolutionY = 1080;
	/// <summary>

	/// </summary>
	public float center_LR_Distance = 0.9f;
	/// <summary>

	/// </summary>
	public float center_UD_Distance = 0.9f;
	private float forbiddenXMin, forbiddenXMax, forbiddenYMin, forbiddenYMax;

	public float mousePosX;
	public float mousePosY;

	public Vector3 mousePositionOnScreen;

	public Vector3 TragetMovePos;

	void Awake()
	{

		/*  transform.position = target.position;
          transform.rotation = Quaternion.Euler(y, x, 0);*/
		TragetMovePos = transform.position;

		// cam.localPosition = new Vector3(0, 0, distance);
		forbiddenXMin = resolutionX * 0.5f - resolutionX * 0.5f * center_LR_Distance;
		forbiddenXMax = resolutionX * 0.5f + resolutionX * 0.5f * center_LR_Distance;
		forbiddenYMin = resolutionY * 0.5f - resolutionY * 0.5f * center_UD_Distance;
		forbiddenYMax = resolutionY * 0.5f + resolutionY * 0.5f * center_UD_Distance;

	}
	void LateUpdate()
	{
		if (Input.GetAxis("Mouse ScrollWheel") != 0)
		{

			distance += Input.GetAxis("Mouse ScrollWheel") * posZSpeed;
			distance = Mathf.Clamp(distance, maxDistance, minDistance);
			TragetMovePos.z = distance;
			// Camera.main.transform.localPosition= new Vector3(camPostion_x, camPostion_y, distance);
		}


		mousePositionOnScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

		if (mousePositionOnScreen.x > resolutionX || mousePositionOnScreen.x < 0 || mousePositionOnScreen.y > resolutionY || mousePositionOnScreen.y < 0)
		{
			return;
		}

		if (mousePositionOnScreen.x > forbiddenXMin && mousePositionOnScreen.x < forbiddenXMax && mousePositionOnScreen.y > forbiddenYMin && mousePositionOnScreen.y < forbiddenYMax)
		{
			//return;
			mousePosX = 0;
			mousePosY = 0;
		}
		else
		{

			if (mousePositionOnScreen.x > forbiddenXMax)
			{

				mousePosX = mousePositionOnScreen.x - forbiddenXMax;
			}
			else if (mousePositionOnScreen.x < forbiddenXMin)
			{

				mousePosX = mousePositionOnScreen.x - forbiddenXMin;
			}
			else
			{
				mousePosX = transform.position.x;
			}

			if (mousePositionOnScreen.y > forbiddenYMax)
			{
				mousePosY = mousePositionOnScreen.y - forbiddenYMax;
			}
			else if ((mousePositionOnScreen.y < forbiddenYMin))
			{

				mousePosY = mousePositionOnScreen.y - forbiddenYMin;
			}
			else
			{
				mousePosY = transform.position.y;
			}

			UpdateTarget_Point();
		}


	}

	private void UpdateTarget_Point()
	{
		if (!IsControl) return;
		Vector2 add = (Vector2)mousePositionOnScreen - new Vector2(resolutionX * 0.5f, resolutionY * 0.5f);
		add = add * moveSpeed;
		Vector3 temple = transform.position + new Vector3(add.x, add.y, 0);
		temple.x = Mathf.Clamp(temple.x, MaxX.x, MaxX.y);
		temple.y = Mathf.Clamp(temple.y, MaxY.x, MaxY.y);
		temple.z = distance;
		TragetMovePos = temple;
	}

	private void Update()
	{
		transform.position = Vector3.LerpUnclamped(transform.position, TragetMovePos, 0.33f);
	}

}
