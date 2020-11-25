Shader "Avalin/T-Shirt-Shader-UV-Separator"
{
	Properties
	{
		_MainColor("Base Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Color2("Color Inside + Sleeve Line", Color) = (1,1,1,1)
		_Color3("Color Sleeve Lines", Color) = (1,1,1,1)
		_Color4("Color Outlines", Color) = (1,1,1,1)
		_Color5("Sleeve Line Left", Color) = (1,1,1,1)
		_Color6("Color Random", Color) = (1,1,1,1)
		_Helper("Helper", Vector) = (1.,1.,1.)
	}
		SubShader
		{
			Tags { "RenderType" = "Opaque" }
			LOD 200
				Cull Off
			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			#pragma surface surf Standard fullforwardshadows



			// Use shader model 3.0 target, to get nicer looking lighting
			#pragma target 3.0

			sampler2D _MainTex;

			struct Input
			{
				float2 uv_MainTex;
			};

			fixed4 _MainColor;
			fixed4 _Color2;
			fixed4 _Color3;
			fixed4 _Color4;
			fixed4 _Color5;
			fixed4 _Color6;
			fixed4 _Helper;



			void surf(Input IN, inout SurfaceOutputStandard o)
			{
				float2 uv = IN.uv_MainTex;

				//Adjusted uv. No need to mess with offset
				uv -= float2(0.75, 1.25);


				/*
				Example of mask stolen from Adam
				sleeveMask
				float mask = sine(uv*10., _Helper / 10.);
				fixed front = lerp(_Color.rbg, _Color2.rbg, mask);

				//mask = circle();
				front = lerp(front, _Color3.rbg, maks);
				*/


				//Finding uv's for the different parts.
				//Adjusted _Helper.x until desired area covered in color.
				/*
				if (uv.x < _Helper.x)
				{
					col = _Color2;
				}
				*/


				//Back uv
				fixed3 col = _MainColor * tex2D(_MainTex, uv);

				//Front uv
				if (uv.x < -0.25)
				{
					col = _Color2 * tex2D(_MainTex, uv);;
				}

				//Color uv
				if (uv.y < -0.931)
				{
					col = _Color3;
				}

				//Sleeves uv
				if (uv.y < -0.96)
				{
					col = _Color4;
				}

				//Sleeve-Edge uv
				if (uv.y < -1.166)
				{
					col = _Color5;
				}

				//Color uv
				if (uv.y < -1.19)
				{
					col = _Color6;
				}

				//The _MainTex is rendered beneath. 
				//Used when adjusting UV up above.

				//fixed4 c = tex2D(_MainTex, uv) * _MainColor;
				
				
				//o.Albedo = c.rgb;
				o.Albedo = col;
			}
			ENDCG
		}
			FallBack "Diffuse"
}
