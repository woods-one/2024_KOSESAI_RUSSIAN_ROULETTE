using UnityEngine;
using UnityEngine.UI;
using OpenCvSharp;
using Rect = UnityEngine.Rect;

public class WebCam : MonoBehaviour {

    [SerializeField] RawImage rawImage;
    [SerializeField] RawImage _rawImage;
    Texture2D _texture;
    private Texture2D dstTexture;
    WebCamTexture webCamTexture;
    
    bool isPlaying;
    private bool isGray;
    private bool isHoge;

    void Start ()  {
        webCamTexture = new WebCamTexture(512, 512, 60);
        rawImage.texture = this.webCamTexture;
        webCamTexture.Play();
        isPlaying = true;
        isGray = false;
        isHoge = false;
    }

    void Update()
    {
        if (Input.GetKey (KeyCode.E) && isPlaying)
        {
            var tex = rawImage.texture;
            var sw = tex.width;
            var sh = tex.height;
            _texture = new Texture2D(sw, sh, TextureFormat.RGBA32, false);
            
            var currentRT = RenderTexture.active;
            var rt = new RenderTexture(sw, sh, 32);
            
            Graphics.Blit(tex, rt);
            RenderTexture.active = rt;
            
            _texture.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
            _texture.Apply();
            RenderTexture.active = currentRT;
            
            _rawImage.texture = _texture;
            isPlaying = false;
            webCamTexture.Stop();
        }
        
        if (Input.GetKey (KeyCode.D) && isGray == false)
        {
            isGray = true;
            Mat srcMat = OpenCvSharp.Unity.TextureToMat(_texture);
            
            Mat grayMat = new Mat();        
            Cv2.CvtColor(srcMat, grayMat, ColorConversionCodes.RGBA2GRAY);
            
            if (this.dstTexture == null) 
            {
                this.dstTexture = new Texture2D(grayMat.Width, grayMat.Height, TextureFormat.RGBA32, false);
            }
            OpenCvSharp.Unity.MatToTexture(grayMat, this.dstTexture);

            _rawImage.texture = dstTexture;
        }
        if (Input.GetKey (KeyCode.C) && isHoge == false)
        {
            isHoge = true;
            rawImage.texture = dstTexture;
        }
    }
}