using UnityEngine;

public class pLine : MonoBehaviour
{
    public Vector3 supportVector = new Vector3(1, 2, 0);
    public Vector3 directionVector = new Vector3(1, 1, 0);
    public float length;
    [SerializeField] private LineRenderer lineRenderer;

    void Update()
    {
        if (lineRenderer != null)
        {
            lineRenderer.SetPosition(0, supportVector - 20 * directionVector);
            lineRenderer.SetPosition(1, supportVector + 20 * directionVector);
        }
    }

    public Vector3 IntersectionPoint(pLine otherLine)
    {


        float a = directionVector.x;
        float b = otherLine.directionVector.x; 
        float c = directionVector.y;
        float d = otherLine.directionVector.y;

        float e = otherLine.supportVector.x - supportVector.x;
        float f = otherLine.supportVector.y - supportVector.y;    

        Matrix2x2 matrix = new Matrix2x2(a, -b, c, -d);
        Matrix2x2 leftMatrix = new Matrix2x2(e, -b, f, -d);

        return supportVector + directionVector * leftMatrix.Determinant() / matrix.Determinant();
    }
}
