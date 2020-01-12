using System.Collections;
using UnityEngine;

public class WalkDetector : MonoBehaviour
{
    [SerializeField] GameObject leftHand;
    [SerializeField] GameObject rightHand;
    [Space]
    [SerializeField] float moveFault = 0.03f;

    public bool IsWalking { get; private set; } = false;

    bool isRightMoving = false;
    bool isLeftMoving = false;
    bool isTimer = false;

    float prevLeftY = 0;
    float prevRightY = 0;

    void FixedUpdate()
    {
		float leftDelta = leftHand.transform.position.y - prevLeftY;
		float rightDelta = rightHand.transform.position.y - prevRightY;

		if (Mathf.Abs(leftDelta) > moveFault)
			isLeftMoving = true;
		else if (isLeftMoving && !isTimer)
			StartCoroutine(LeftStopTimer());

		if (Mathf.Abs(rightDelta) > moveFault)
			isRightMoving = true;
		else if (isRightMoving && !isTimer)
			StartCoroutine(RightStopTimer());

		if (isRightMoving && isLeftMoving && ((leftDelta < 0) != (rightDelta < 0)))
			IsWalking = true;
		else if (!isTimer)
			IsWalking = false;

		prevLeftY = leftHand.transform.position.y;
		prevRightY = rightHand.transform.position.y;

		Debug.Log("walking " + IsWalking);
    }

    IEnumerator LeftStopTimer()
    {
        isTimer = true;
        float cur = leftHand.transform.position.y;
        yield return new WaitForSeconds(updateInterval);
        isLeftMoving = Mathf.Abs(cur - leftHand.transform.position.y) > moveFault;
        isTimer = false;
    }

    IEnumerator RightStopTimer()
    {
        isTimer = true;
        float cur = rightHand.transform.position.y;
        yield return new WaitForSeconds(updateInterval);
        isRightMoving = Mathf.Abs(cur - rightHand.transform.position.y) > moveFault;
        isTimer = false;
    }
}