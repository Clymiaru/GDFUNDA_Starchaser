using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBezierPath : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;

    [SerializeField] List<GameObject> points;
    private float timeFactor = 0.0f;

    private void Update()
    {
        if (timeFactor < 1)
        {
            timeFactor += Time.deltaTime * speed;
            gameObject.transform.position = GetPositionOnTimeFactor(timeFactor);
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 prevPosition = points[0].transform.position;
        Vector3 position;

        int numberOfPoints = 20;
        float t;
        for (int i = 0; i < numberOfPoints; i++)
        {
            t = i / (numberOfPoints - 1.0f);
            position = GetPositionOnTimeFactor(t);

            Gizmos.color = new Color(0.8f, 0.5f, 0.0f);
            Gizmos.DrawLine(prevPosition, position);
            prevPosition = position;
        }
    }

    private Vector3 GetPositionOnTimeFactor(float t)
    {
        Vector3 currentPosition = new Vector3();
        float oneMinusT = 1.0f - t;

        for (int i = 0; i < points.Count; i++)
        {
            var scale = BinomialCalc(points.Count - 1, i, oneMinusT, t);
            currentPosition += scale * points[i].transform.position;
            //Debug.Log($"Position: {currentPosition.x}, { currentPosition.y}, {currentPosition.z}");
        }

        return currentPosition;
        //return Mathf.Pow(oneMinusT, 3) * p0 +
        //    3.0f * Mathf.Pow(oneMinusT, 2) * t * p1 +
        //    3.0f * oneMinusT * t * t * p2 +
        //    t * t * t * p3;
    }

    //Binomial Theorem Calculation

    private int Factorial(int n)
    {
        if (n == 1 || n == 0)
            return 1;
        else if (n < 0)
        {
            return -1; // Cannot be determined
        }

        int curr = n;
        int result = 1;
        while (curr >= 2)
        {
            result *= curr;
            curr--;
        }
        return result;
    }

    private float BinomialCalc(int maxPow, int currentPow, float term1, float term2)
    {
        float coeff;
        coeff = Factorial(maxPow) / (Factorial(currentPow) * Factorial(maxPow - currentPow));
            Debug.Log(coeff);
        return coeff * Mathf.Pow(term1, maxPow - currentPow) * Mathf.Pow(term2, currentPow); ;
    }

    //private float CalculateTerm(float term1, float term2, int currentPow, int maxPower)
    //{
    //    return Mathf.Pow(term1, maxPower) * Mathf.Pow(term2, maxPower - currentPow);
    //}
}
