Shader "Avalin/T-Shirt-Shader-Duo-Colorino"
{
	/*
	* Takes two colors and ideally two textures, and animates the whole thingamabob to the dance of a sinuswave :D
	*/

    Properties
    {
        _MainColor ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
		_OtherColor("Color", Color) = (1,1,1,1)
		_OtherTex("Albedo (RGB)", 2D) = "white" {}
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
		sampler2D _OtherTex;

        struct Input
        {
            float2 uv_MainTex;
			float2 uv_OtherTex;
        };

        fixed4 _MainColor;
		fixed4 _OtherColor;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
			float2 mainUV = IN.uv_MainTex;
			float2 otherUV = IN.uv_OtherTex;

			//Adjusted uv. No need to mess with offset
			mainUV -= float2(0.75, 1.25);
			otherUV -= float2(0.75, 1.25);

			fixed3 tempCol = _MainColor * tex2D(_MainTex, mainUV);

			if (mainUV.x < -0.25)
			{
				tempCol = _MainColor * tex2D(_MainTex, mainUV);;
			}
			else
			{
				tempCol = _OtherColor * tex2D(_OtherTex, mainUV);;
			}


            // Albedo comes from a texture tinted by color			
			fixed4 c = tex2D(_MainTex, mainUV) * _MainColor;
            o.Albedo = c.rgb;
            o.Alpha = c.a;
			o.Albedo = sin(tempCol * _Time);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
