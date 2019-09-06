Shader "Unlit/PhongShading"
{
	Properties
	{
		_PointLightColor("Point Light Color", Color) = (0, 0, 0)
		_PointLightPosition("Point Light Position", Vector) = (0.0, 0.0, 0.0)
		_Ka("Ka", float) = 0
		_fAtt("fAtt", float) = 0
		_Kd("Kd", float) = 0
		_Ks("Ks", float) = 0
		_specN("specular", float) = 0	
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			uniform float3 _PointLightColor;
			uniform float3 _PointLightPosition;
			uniform float _Ka;
			uniform float _fAtt;
			uniform float _Kd;
			uniform float _Ks;
			uniform float _specN;

			struct vertIn
			{
				float4 vertex : POSITION;
				float4 normal : NORMAL;
				float4 color : COLOR;
			};

			struct vertOut
			{
				float4 vertex : SV_POSITION;
				float3 worldNormal : TEXCOORD0;
				float4 worldVertex : TEXCOORD1;
				float4 color : COLOR;
			};
			
			vertOut vert (vertIn v)
			{
				vertOut o;
				// Convert Vertex position and corresponding normal into world coords.
				float4 worldVertex = mul(unity_ObjectToWorld, v.vertex);
				float3 worldNormal = normalize(mul(transpose((float3x3)unity_WorldToObject), v.normal.xyz));

				// Transform vertex in world coordinates to camera coordinates
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.color = v.color;

				o.worldNormal = worldNormal;
				o.worldVertex = worldVertex;

				return o;
			}

			// Implementation of the fragment shader
			fixed4 frag(vertOut v) : SV_Target
			{
				// Calculate ambient RGB intensities
				float3 amb = v.color.rgb * UNITY_LIGHTMODEL_AMBIENT.rgb * _Ka;

				// Calculate diffuse RBG reflections
				float3 L = normalize(_PointLightPosition - v.worldVertex.xyz);
				float LdotN = dot(L, v.worldNormal.xyz);
				float3 dif = _fAtt * _PointLightColor.rgb * _Kd * v.color.rgb * saturate(LdotN);

				// Phong shading model
				float3 V = normalize(_WorldSpaceCameraPos - v.worldVertex.xyz);
				float3 R = normalize((2.0 * LdotN * v.worldNormal) - L);
				float3 spe = _fAtt * _PointLightColor.rgb * _Ks * pow(saturate(dot(V, R)), _specN);

				// Combine Phong illumination model components
				v.color.rgb = amb.rgb + dif.rgb + spe.rgb;

				return v.color;
			}
			ENDCG
		}
	}
		Fallback "Diffuse"
}
