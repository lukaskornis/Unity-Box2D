using Unity.Mathematics;
using UnityEngine;
using UnityEngine.U2D;

[RequireComponent( typeof( SpriteShapeController ) )]
public class Terrain2D : MonoBehaviour
{
     public int pointCount = 10;
     public float step = 1;
     public float height = 10;
     public float smoothness;
     public float noiseScale = 0.1f;
     public float noiseOffset = 0.1f;
     public float noiseAmplitude = 0.1f;
     void OnValidate()
     {
          GenerateTerrain();
     }

     void GenerateTerrain()
     {
          var spriteShapeController = GetComponent<SpriteShapeController>();
          var spline = spriteShapeController.spline;
          spline.Clear();

          // start edge
          spline.InsertPointAt( 0,Vector3.down * height );

          for (int i = 0; i < pointCount; i++)
          {
               var h = noise.cnoise( new float2( i * noiseScale, noiseOffset ) ) * noiseAmplitude;
               spline.InsertPointAt( i, new Vector3( i * step, h, 0 ) );

               // smooth tangents pointing to the next point
               spline.SetTangentMode( i, ShapeTangentMode.Continuous );

               spline.SetHeight(i, h);
          }

          // end edge
          spline.SetTangentMode( 1, ShapeTangentMode.Linear );
          spline.SetTangentMode( pointCount - 1, ShapeTangentMode.Linear );

          spline.InsertPointAt( pointCount, new Vector3( ( pointCount - 1 ) * step, -height, 0 ) );
     }
}