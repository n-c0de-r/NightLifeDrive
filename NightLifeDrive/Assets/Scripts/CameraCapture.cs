    using System.IO;
    using UnityEngine;
    
    //https://forum.unity.com/threads/how-to-save-manually-save-a-png-of-a-camera-view.506269/
    
    public class CameraCapture : MonoBehaviour
    {
        public int fileCounter;
        public KeyCode screenshotKey;
        private Camera Camera
        {
            get
            {
                if (!_camera)
                {
                    _camera = Camera.main;
                }
                return _camera;
            }
        }
        private Camera _camera;
        private void LateUpdate()
        {
            if (Input.GetKeyDown(screenshotKey))
            {
                Capture();
            }
        }
        
        public void Capture()
        {
            RenderTexture tempRT = new RenderTexture(1920, 1080, 24, RenderTextureFormat.ARGB32)
            {
                antiAliasing = 4
            };
            
            Camera.targetTexture = tempRT; 
            RenderTexture.active = tempRT;
            Camera.Render();
            Texture2D image = new Texture2D(1920, 1080, TextureFormat.ARGB32, false, true);

            image.ReadPixels(new Rect(0, 0, image.width, image.height), 0, 0);
            image.Apply();
            RenderTexture.active = null;
            
            byte[] bytes = image.EncodeToPNG();
            Destroy(image);
            
            File.WriteAllBytes(Application.dataPath + "/Backgrounds/" + fileCounter + ".png", bytes);
      

            fileCounter++;
        }
    }
