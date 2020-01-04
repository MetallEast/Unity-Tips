using System.Collections;
using UnityEngine;

public class WalkDetector : MonoBehaviour
{
    [SerializeField] GameObject leftHand;
    [SerializeField] GameObject rightHand;

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

        if (leftDelta != 0)
            isLeftMoving = true;
        else
            StartCoroutine(LeftStopTimer());

        if (rightDelta != 0)
            isRightMoving = true;
        else if (!isTimer)
            StartCoroutine(RightStopTimer());

        if (isRightMoving && isLeftMoving && ((leftDelta < 0) != (rightDelta < 0)))
            IsWalking = true;
        else if (!isTimer)
            IsWalking = false;

        prevLeftY = leftHand.transform.position.y;
        prevRightY = rightHand.transform.position.y;

        Debug.Log(IsWalking);
    }

    IEnumerator LeftStopTimer()
    {
        isTimer = true;
        float cur = leftHand.transform.position.y;
        yield return new WaitForSeconds(0.2f);
        isLeftMoving = cur != leftHand.transform.position.y;
        isTimer = false;
    }

    IEnumerator RightStopTimer()
    {
        isTimer = true;
        float cur = rightHand.transform.position.y;
        yield return new WaitForSeconds(0.2f);
        isRightMoving = cur != rightHand.transform.position.y;
        isTimer = false;
    }
}