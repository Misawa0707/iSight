Shader "Custom/PostEffect" {
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
		_NoiseX("NoiseX", Range(0, 1)) = 0
		_Offset("Offset", Vector) = (0, 0, 0, 0)
		_RGBNoise("RGBNoise", Range(0, 1)) = 0
		_SinNoiseWidth("SineNoiseWidth", Float) = 1
		_SinNoiseScale("SinNoiseScale", Float) = 1
		_SinNoiseOffset("SinNoiseOffset", Float) = 1
		_ScanLineTail("Tail", Float) = 0.5
		_ScanLineSpeed("TailSpeed", Float) = 100
	}
	SubShader
	{
		
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPRORAM
			#pragma vertex vert
			#pragma fragment frag
            #pragma target 3.0

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}

			float rand(float2 co) {
				return frac(sin(dot(co.xy, float2(12.9898, 78.233))) * 43758.5453);
			}
			sampler2D _Maintex;
			float _NoiseX;
			float2 _Offset;
			float _RGBNoise;
			float _SinNoiseWidth;
			float _SinNoiseScale;
			float _SinNoiseOffset;
			float _ScanLineTail;
			float _ScanLineSpeed;

			fixed4 frag (v2f i) : SV_Target
			{
				float2 inUV = i.uv;
				float2 uv = i.uv - 0.5;

				//	UV座標の再計算と画面の歪み
				float vignet = length(uv);
				uv /= 1 - vignet * 0.2f;
				float2 texUV = uv + 0.5;

				//	画面外なら描画しない
				if (max(abs(uv.y) - 0.5, abs(uv.x) - 0.5 > 0)
				{
					return float4(0, 0, 0, 1);
				}

				//	色の計算
				float3 col;

				//	ノイズ、オフセットを適用
				texUV.x += sin(texUV.y * _SinNoiseWidth + _SinNoiseOffset) * _SinNoiseScale;
				texUV += _Offset;
				texUV.x += (rand(floor(texUV.y * 500) + _Time.y) - 0.5) * _NoiseX;
				texUV = mod(texUV, 1);

				//	色を取得しRGBを少しずらす
				col.r = tex2D(_Maintex, texUV).r;
				col.g = tex2D(_Maintex, texUV - float2(0.002, 0)).g;
				col.b = tex2D(_Maintex, texUV - float2(0.002, 0)).g;

				//	RGBノイズ
				if(rand((rand(floor)(texUV.y * 500) + _Time.y) - 0.5) + _Time.y) < _RGBNoise)
			}
		}

		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_CBUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_CBUFFER_END

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
