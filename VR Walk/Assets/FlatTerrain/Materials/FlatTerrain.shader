// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Flat/Terrain"
{
	Properties
	{
		_Control("SplatMap (RGBA)", 2D) = "red" {}
		_Splat0("Layer 0 (R)", 2D) = "white" {}
		_Splat1("Layer 1 (G)", 2D) = "white" {}
		_Splat2("Layer 2 (B)", 2D) = "white" {}
		_Splat3("Layer 3 (A)", 2D) = "white" {}
		_BaseMap("BaseMap (RGB)", 2D) = "white" {}
		_RimPower("Rim Power", Range(0.01, 10.0)) = 3.0
		_Color("Rim Color", Color) = (0,0,0,1)

	}
		SubShader{
		Tags{
		"RenderType" = "Opaque"
	}
		Pass{
		Name "FORWARD"
		Tags{
		"LightMode" = "ForwardBase"
	}

		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#define UNITY_PASS_FORWARDBASE
		#include "UnityCG.cginc"
		#include "AutoLight.cginc"
		#pragma multi_compile_fwdbase_fullshadows
		#pragma multi_compile_fog
		#pragma exclude_renderers metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
		#pragma target 3.0
		#pragma glsl
		uniform float4 _LightColor0;
		#pragma shader_feature __ HARD_EDGES RIM_LIGHTING
		#pragma shader_feature __ RIM_LIGHTING

	struct VertexOutput {
		float4 pos : SV_POSITION;
		float3 normalDir : NORMAL;
		float3 posWorld : TEXCOORD0;
		half4 uv[3] : TEXCOORD1;
		LIGHTING_COORDS(4, 5)
		UNITY_FOG_COORDS(6)
	};

	uniform sampler2D _Control;
	uniform half4 _Control_ST;

	uniform sampler2D _Splat0, _Splat1, _Splat2, _Splat3;
	uniform half4 _Splat0_ST, _Splat1_ST, _Splat2_ST, _Splat3_ST;
	uniform half _RimPower;

	VertexOutput vert(appdata_base v)
	{
		VertexOutput o = (VertexOutput)0;
		o.normalDir = UnityObjectToWorldNormal(v.normal);
		o.posWorld = mul(unity_ObjectToWorld, v.vertex);
		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
		UNITY_TRANSFER_FOG(o, o.pos);
		TRANSFER_VERTEX_TO_FRAGMENT(o)

		o.uv[0].xy = TRANSFORM_TEX(v.texcoord.xy, _Control);
		o.uv[0].zw = half2(0, 0);
		o.uv[1].xy = TRANSFORM_TEX(v.texcoord.xy, _Splat0);
		o.uv[1].zw = TRANSFORM_TEX(v.texcoord.xy, _Splat1);
		o.uv[2].xy = TRANSFORM_TEX(v.texcoord.xy, _Splat2);
		o.uv[2].zw = TRANSFORM_TEX(v.texcoord.xy, _Splat3);

		return o;
	}

	float3 getRim(half3 posWorld, half3 normal) {
#ifdef RIM_LIGHTING
		half3 viewDirection = normalize(_WorldSpaceCameraPos - posWorld);
		half rim = 1.0 - saturate(dot(normalize(viewDirection), normal));
		float3 rimCol = pow(rim, _RimPower);
		return rimCol;
#else
		return float3(0, 0, 0);
#endif
	}

	fixed4 frag(VertexOutput i) : SV_Target
	{
		float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
#if UNITY_UV_STARTS_AT_TOP
		float3 normalDirection;
		if (_ProjectionParams.x < 0)
			normalDirection = cross(normalize(ddy(i.posWorld.rgb)), normalize(ddx(i.posWorld.rgb)));
		else
			normalDirection = cross(normalize(ddx(i.posWorld.rgb)), normalize(ddy(i.posWorld.rgb)));
#else
		float3 normalDirection;
		if (_ProjectionParams.x < 0)
			normalDirection = cross(normalize(ddx(i.posWorld.rgb)), normalize(ddy(i.posWorld.rgb)));
		else
			normalDirection = cross(normalize(ddy(i.posWorld.rgb)), normalize(ddx(i.posWorld.rgb)));
#endif
		float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
		float3 lightColor = _LightColor0.rgb;

		half4 splat_control = tex2D(_Control, i.uv[0].xy);

#ifdef HARD_EDGES
		splat_control = normalize(splat_control);
		splat_control.r = round(splat_control.r);
		splat_control.g = saturate(round(splat_control.g - splat_control.r));
		splat_control.b = saturate(round(splat_control.b - splat_control.g));
		splat_control.a = saturate(round(splat_control.a - splat_control.b));
#endif

		half3 splat_color = splat_control.r * tex2D(_Splat0, i.uv[1].xy).rgb;
		splat_color += splat_control.g * tex2D(_Splat1, i.uv[1].zw).rgb;
		splat_color += splat_control.b * tex2D(_Splat2, i.uv[2].xy).rgb;
		splat_color += splat_control.a * tex2D(_Splat3, i.uv[2].zw).rgb;

		////// Lighting:
		float attenuation = LIGHT_ATTENUATION(i);
		float3 attenColor = attenuation * _LightColor0.xyz;
		float3 rim = getRim(i.posWorld, normalDirection);
		float Pi = 3.141592654;
		float InvPi = 0.31830988618;
		/////// Diffuse:
		float NdotL = max(0.0, dot(normalDirection, lightDirection));
		float3 directDiffuse = max(0.0, NdotL) * attenColor;
		float3 indirectDiffuse = float3(0, 0, 0);
		indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
		indirectDiffuse += rim;
		float3 diffuseColor = splat_color;
		float3 diffuse = (directDiffuse + indirectDiffuse ) * diffuseColor;
		/// Final Color:
		float3 finalColor = diffuse;
		fixed4 finalRGBA = fixed4(finalColor, 1);
		UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
		return finalRGBA;

	}
		ENDCG
	}
	}
}
