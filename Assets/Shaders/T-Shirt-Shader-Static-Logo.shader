Shader "Avalin/T-Shirt-Shader-Static-Logo"
{	
	/*
	 * This shader put simply takes two textures, and blend these.
	 * The MainTex is the background texture, and the _LogoTex is the logo on the t-shirt.
	 * This makes it possible to create static (non-animated), but funky t-shirt designs!
	 *
	 * MainTex: Background texture for t-shirt!
	 * Logo: Logo texture for t-shirt!
	 * Splash map: Defines how much of logo is shown! (White pixels are shown, black pixels are not)
	 */

    Properties
    {
        _MainColor ("Base Color", Color) = (1,1,1,1)
        _MainTex ("Base Texture", 2D) = "white" {}
		_LogoColor("Logo Color", Color) = (1,1,1,1)
		_LogoTex ("Logo Texture", 2D) = "white" {}
		_SplashTex ("Splash Map", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
		sampler2D _LogoTex;
		sampler2D _SplashTex;

        struct Input
        {
            float2 uv_MainTex;
			float2 uv_LogoTex;
			float2 uv2_SplashTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _MainColor;
		fixed4 _LogoColor;

        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 MainColor = tex2D (_MainTex, IN.uv_MainTex) * _MainColor;
			fixed4 LogoColor = tex2D(_LogoTex, IN.uv_MainTex) * _LogoColor;
			fixed4 SplashColor = tex2D(_SplashTex, IN.uv2_SplashTex);
			fixed4 c = SplashColor;

			/*
			* This is where the magic happens! All the texture colors are put together, but in the end, we delete the SplashColor from the alpha.
			* This is what makes the 2 textures overlap without the issues that comes with blending! (Transparency will show as actual transparent or black,
			* and the background texture won't show)
			*/

            o.Albedo = (LogoColor.rgb * SplashColor.rgb + MainColor * ( 1 - SplashColor.rgb));
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
