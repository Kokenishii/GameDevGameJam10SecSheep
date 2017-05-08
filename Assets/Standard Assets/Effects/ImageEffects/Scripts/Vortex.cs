using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    [AddComponentMenu("Image Effects/Displacement/Vortex")]

    public class Vortex : ImageEffectBase
    {
 
        public Vector2 radius = new Vector2(0.4F,0.4F);
        public float angle = 50;
        public Vector2 center = new Vector2(0.5F, 0.5F);
        int counter = 0;
        public GameObject VortexRef;
        // Called by camera to apply image effect
        void OnRenderImage (RenderTexture source, RenderTexture destination)
        {
          
            if(VortexRef.activeSelf)
            {
               
                if (counter < 160)
                {
                    center = new Vector2(center.x + 0.05f, center.y);
                    counter++;
                }
                else
                {
                    counter = 0;
                    center = new Vector2(-0.2f, center.y);
                }
            }
            else
            {
                counter = 0;
                center = new Vector2(-0.2f, center.y);
            }
                

                ImageEffects.RenderDistortion(material, source, destination, angle, center, radius);
            
           
        }
    }
}
