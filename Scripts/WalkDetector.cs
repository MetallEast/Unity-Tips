using System.Collections;
using UnityEngine;

public class WalkDetector : MonoBehaviour
{
    [SerializeField] Transform leftHand;
    [SerializeField] Transform rightHand;
    [Space]
    [SerializeField] float moveFault = 0.03f;

    public bool IsWalking { get; private set; } = false;
    
    static WaitForSeconds waitTime = new WaitForSeconds(updateInterval);
    
    bool isRightMoving = false;
    bool isLeftMoving = false;
    bool isTimer = false;

    float prevLeftY = 0;
    float prevRightY = 0;

    void FixedUpdate()
    {
		var leftDelta = leftHand.position.y - prevLeftY;
		var rightDelta = rightHand.position.y - prevRightY;

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

		prevLeftY = leftHand.position.y;
		prevRightY = rightHand.position.y;
    }

    IEnumerator LeftStopTimer()
    {
        isTimer = true;
        var cur = leftHand.position.y;
        yield return waitTime;
        isLeftMoving = Mathf.Abs(cur - leftHand.position.y) > moveFault;
        isTimer = false;
    }

    IEnumerator RightStopTimer()
    {
        isTimer = true;
        var cur = rightHand.position.y;
        yield return waitTime;
        isRightMoving = Mathf.Abs(cur - rightHand.position.y) > moveFault;
        isTimer = false;
    }
}
