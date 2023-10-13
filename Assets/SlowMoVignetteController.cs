using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SlowMoVignetteController : MonoBehaviour
{
   public Camera mainCamera;
   public Animator gunAnimator;
   private static SlowMoVignetteController _instance;
   public static SlowMoVignetteController Instance
   {
      get
      {
         if (SlowMoVignetteController._instance == null)
            SlowMoVignetteController._instance = FindObjectOfType<SlowMoVignetteController>();

         return SlowMoVignetteController._instance;
      }
   }


   public void VignetteAppear()
   {
      mainCamera.GetUniversalAdditionalCameraData().renderPostProcessing = true;
      gunAnimator.SetBool("inSlowMo", true);
   }

   public void VignetteDesappear()
   {
      mainCamera.GetUniversalAdditionalCameraData().renderPostProcessing = false;
      gunAnimator.SetBool("inSlowMo", false);
   }
}
