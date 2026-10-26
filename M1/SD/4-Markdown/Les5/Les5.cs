using UnityEngine;

public class Les5 : MonoBehaviour
{
    [SerializeField] private pLine line1;
    [SerializeField] private pLine line2;
    [SerializeField] private Transform intersectionPoint;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float a = line1.directionVector.x;
        float b = line2.directionVector.x; 
        float c = line1.directionVector.y;
        float d = line2.directionVector.y;

        float e = line2.supportVector.x - line1.supportVector.x;
        float f = line2.supportVector.y - line1.supportVector.y;    




        Matrix2x2 matrix = new Matrix2x2(a, -b, c, -d);
        Matrix2x2 leftMatrix = new Matrix2x2(e, -b, f, -d);

        intersectionPoint.position = line1.supportVector + line1.directionVector * leftMatrix.Determinant() / matrix.Determinant();
        
    }
}
