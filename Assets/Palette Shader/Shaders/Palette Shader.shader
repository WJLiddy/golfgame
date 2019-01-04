// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Palette Shader/Palette Shader" {

	Properties {
		_MainTex("Sprite Texture", 2D) = "white" { }
		colourReferenceTexture("Colour Reference Texture", 3D) = "white" { }
		brightness("Brightness", Float) = 0
		contrast("Contrast", Float) = 0
		pixelation("Pixelation", Float) = 0
	}

	SubShader {
		ZTest Always
		Pass {
			CGPROGRAM
				#pragma vertex vertexShader
				#pragma fragment fragmentShader
				sampler2D _MainTex;
				sampler3D colourReferenceTexture;
				float brightness, contrast;
				float pixelation;

				//Vertex to fragment.
				struct VertexToFragment {
					float4 position : POSITION0;
					float2 textureCoordinates : TEXCOORD0;
				};

				//Vertex shader.
				VertexToFragment vertexShader(float4 vertexPosition : POSITION0, float2 textureCoordinates : TEXCOORD0) {
					VertexToFragment vertexToFragment;
					vertexToFragment.position = UnityObjectToClipPos(vertexPosition);
					vertexToFragment.textureCoordinates = textureCoordinates;
					return vertexToFragment;
				}

                //Fragment shader.
                float4 fragmentShader(VertexToFragment vertexToFragment) : Color{
                    float4 colour;
                    if (pixelation > 0.0001) {
                        float pixelationDenominator = (1 - pow(pixelation, 0.125)) * _ScreenParams.x;
                        colour = tex2D(_MainTex, float2(floor((vertexToFragment.textureCoordinates.x * pixelationDenominator) + 0.5) / pixelationDenominator,
                            floor((vertexToFragment.textureCoordinates.y * pixelationDenominator * (_ScreenParams.y / _ScreenParams.x)) + 0.5) /
                            (pixelationDenominator * (_ScreenParams.y / _ScreenParams.x))));
                    }
                    else
                        colour = tex2D(_MainTex, vertexToFragment.textureCoordinates);
                    colour += float4(brightness, brightness, brightness, 0);
                    colour.r = ((colour.r - 0.5) * (contrast + 1)) + 0.5;
                    colour.g = ((colour.g - 0.5) * (contrast + 1)) + 0.5;
                    colour.b = ((colour.b - 0.5) * (contrast + 1)) + 0.5;
                    return tex3D(colourReferenceTexture, colour.rgb);
                }
			ENDCG
		}
	}
}