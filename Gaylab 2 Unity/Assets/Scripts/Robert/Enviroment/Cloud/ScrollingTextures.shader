﻿ Shader "Custom/ScrollingTextures" {
// 	Properties {
// 		_Color ("Color", Color) = (1,1,1,1)
// 		_MainTex ("Albedo (RGB)", 2D) = "white" {}
// 		_Glossiness ("Smoothness", Range(0,1)) = 0.5
// 		_Metallic ("Metallic", Range(0,1)) = 0.0
// 		_ScrollXSpeed("X Scroll Speed", Range(0,10)) = 2
// 		_ScrollYSpeed("Y Scroll Speed", Range(0,10)) = 2
// 		_Cutoff ( "Cutoff", Range(0,1)) =5
// 	}
// 	SubShader {
// 		Tags { "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" }
// 		LOD 200
		
// 		CGPROGRAM
// 		// Physically based Standard lighting model, and enable shadows on all light types
// 		#pragma surface surf Standard fullforwardshadows 

// 		// Use shader model 3.0 target, to get nicer looking lighting
// 		#pragma target 3.0

// 		sampler2D _MainTex;
// 		half _Glossiness;
// 		half _Metallic;
// 		fixed4 _Color;
// 		fixed _ScrollXSpeed;
// 		fixed _ScrollYSpeed;

// 		struct Input {
// 			float2 uv_MainTex;
// 		};


// 		void surf (Input IN, inout SurfaceOutputStandard o) {
			
// 			fixed2 scrolledUV = IN.uv_MainTex;
// 			fixed xScrollValue = _ScrollXSpeed * _Time;
// 			fixed yScrollValue = _ScrollYSpeed * _Time;

// 			scrolledUV += fixed2(xScrollValue , yScrollValue);
			
			
// 			fixed4 c = tex2D (_MainTex, scrolledUV) * _Color;
// 			o.Albedo = c.rgb;
// 			o.Metallic = _Metallic;
// 			o.Smoothness = _Glossiness;
// 			o.Alpha = c.a;
			
// 		}
// 		ENDCG
// 	 }
// 	FallBack "Diffuse"
  }	