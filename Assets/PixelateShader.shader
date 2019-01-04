Shader "PixelateShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_PixelSize("Pixel Size", Range(0.001, 0.1)) = 1.0
		_QuantCount("Quant Count", Range(0.001, 1.0)) = 1.0
	}
		SubShader
	{
		Tags{ "RenderType" = "Opaque" }

		Pass
	{
		CGPROGRAM
#pragma vertex vert_img
#pragma fragment frag
#include "UnityCG.cginc"

	sampler2D _MainTex;
	float _PixelSize;
	float _QuantCount;

	fixed lossyRound(fixed i, float quantLevel)
	{
		// First, find bin.
		int bin = (i / quantLevel);
		return bin * quantLevel;
	}

	fixed4 frag(v2f_img i) : SV_Target
	{
		fixed4 col;
	float ratioX = (int)(i.uv.x / _PixelSize) * _PixelSize;
	float ratioY = (int)(i.uv.y / _PixelSize) * _PixelSize;
	col = tex2D(_MainTex, float2(ratioX, ratioY));


	// Original Gameboy RGB Colors :
	// 15, 56, 15
	// 48, 98, 48
	// 139, 172, 15
	// 155, 188, 15


	col = fixed4(lossyRound(col.r,_QuantCount), lossyRound(col.g, _QuantCount), lossyRound(col.b, _QuantCount), 1.0);
	if (col.r) {}

	return col;
	}

		ENDCG
	}
	}
}