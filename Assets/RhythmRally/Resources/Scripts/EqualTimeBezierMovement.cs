using UnityEngine;

public class EqualTimeBezierMovement : MonoBehaviour
{
    public Transform[] points; // 4개의 목표 위치 (시작점, 중간 제어점들, 끝점)
    public float totalTime = 3f; // 전체 이동 시간
    private float[] segmentDistances;
    private float[] segmentRatios;
    private float elapsedTime = 0f;

    private int currentSegment = 0;
    private Vector3 previousPosition;

    private void Start()
    {
        if (points.Length < 4)
        {
            Debug.LogError("4개의 목표 위치가 필요합니다.");
            return;
        }

        CalculateDistances();
        previousPosition = transform.position;
    }

    private void Update()
    {
        if (currentSegment >= points.Length - 2) return; // 마지막 구간까지 완료된 경우

        elapsedTime += Time.deltaTime;

        // 현재 구간의 진행 시간
        float segmentTime = totalTime * segmentRatios[currentSegment];
        float t = Mathf.Clamp01(elapsedTime / segmentTime);

        if (t >= 1f)
        {
            t = 1f;
            elapsedTime = 0f;
            currentSegment++;
        }

        if (currentSegment < points.Length - 2)
        {
            Vector3 start = points[currentSegment].position;
            Vector3 control = points[currentSegment + 1].position;
            Vector3 end = points[currentSegment + 2].position;

            // 2차 베지어 곡선을 따라 이동
            Vector3 nextPosition = CalculateQuadraticBezierPoint(t, start, control, end);

            // 이전 위치에서 돌아가지 않도록 보정
            if (Vector3.Distance(previousPosition, nextPosition) > 0.01f)
            {
                transform.position = nextPosition;
                previousPosition = nextPosition;
            }
        }
    }

    private void CalculateDistances()
    {
        int segmentCount = points.Length - 2; // 베지어 곡선 구간 수
        segmentDistances = new float[segmentCount];
        segmentRatios = new float[segmentCount];
        float totalDistance = 0f;

        // 각 구간의 거리 계산 (곡선을 샘플링하여 근사 계산)
        for (int i = 0; i < segmentCount; i++)
        {
            Vector3 start = points[i].position;
            Vector3 control = points[i + 1].position;
            Vector3 end = points[i + 2].position;

            segmentDistances[i] = EstimateBezierCurveLength(start, control, end);
            totalDistance += segmentDistances[i];
        }

        // 구간 비율 계산
        for (int i = 0; i < segmentCount; i++)
        {
            segmentRatios[i] = segmentDistances[i] / totalDistance;
        }
    }

    private float EstimateBezierCurveLength(Vector3 p0, Vector3 p1, Vector3 p2)
    {
        int sampleCount = 20; // 샘플링 횟수
        float length = 0f;
        Vector3 previousPoint = p0;

        for (int i = 1; i <= sampleCount; i++)
        {
            float t = i / (float)sampleCount;
            Vector3 currentPoint = CalculateQuadraticBezierPoint(t, p0, p1, p2);
            length += Vector3.Distance(previousPoint, currentPoint);
            previousPoint = currentPoint;
        }

        return length;
    }

    private Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        return u * u * p0 + 2 * u * t * p1 + t * t * p2;
    }
}
