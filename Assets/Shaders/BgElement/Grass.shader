Shader "Unlit/Grass"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _TopCol("Top Color", Color) = (0, 0, 0, 0)
        _BotCol("Bottom Color", Color) = (0, 0, 0, 0)
        _BendRRand("Bend Rotation Random", Range(0, 1)) = 0.2
        _BladeW("Blade Width", float) = 0.05
        _BladeWRand("Blade Width Randome", Float) = 0.02
        _BladeH("Blade Height", Float) = 0.5
        _BladeHtRand("Blade Height Randome", Float) = 0.3
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        cull off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma geometry geo

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
            };

            struct v2g
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
            };

            struct g2f
            {
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            fixed4 _TopCol;
            fixed4 _BotCol;

            float _BendRRand;

            float _BladeH;
            float _BladeHRand;	
            float _BladeW;
            float _BladeWRand;

            v2g vert (appdata v)
            {
                v2g o;
                o.vertex = v.vertex;
	            o.normal = v.normal;
	            o.tangent = v.tangent;
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            g2f VertexOutput(float3 pos, float2 uv)
            {
	            g2f o;
	            o.pos = UnityObjectToClipPos(pos);
                o.uv = uv;
	            return o;
            }

            float3x3 AngleAxis3x3(float angle, float3 axis)
	        {
		        float c, s;
		        sincos(angle, s, c);

		        float t = 1 - c;
		        float x = axis.x;
		        float y = axis.y;
		        float z = axis.z;

		        return float3x3(
			        t * x * x + c, t * x * y - s * z, t * x * z + s * y,
			        t * x * y + s * z, t * y * y + c, t * y * z - s * x,
			        t * x * z - s * y, t * y * z + s * x, t * z * z + c
			        );
	        }

            float rand(float3 co)
	        {
		        return frac(sin(dot(co.xyz, float3(12.9898, 78.233, 53.539))) * 43758.5453);
	        }

            [maxvertexcount(3)]
            void geo (triangle v2g input[3], inout TriangleStream<g2f> triStream)
            {
                float3 vNormal = input[0].normal;
                float4 vTangent = input[0].tangent;
                float3 vBinormal = cross(vNormal, vTangent) * vTangent.w;

                float3x3 tangentToLocal = float3x3(
	            vTangent.x, vBinormal.x, vNormal.x,
	            vTangent.y, vBinormal.y, vNormal.y,
	            vTangent.z, vBinormal.z, vNormal.z
	            );

                float3x3 facingRotationMatrix = AngleAxis3x3(rand(input[0].vertex) * UNITY_TWO_PI, float3(0, 0, 1));

                float3x3 bendRotationMatrix = AngleAxis3x3(rand(input[0].vertex.zzx) * _BendRRand * UNITY_PI * 0.5, float3(-1, 0, 0));

                float3x3 transformationMatrix = mul(mul(tangentToLocal, facingRotationMatrix), bendRotationMatrix);

                float w = (rand(input[0].vertex.xzy) * 2 - 1) * _BladeWRand + _BladeW;
                float h = (rand(input[0].vertex.zyx) * 2 - 1) * _BladeHRand + _BladeH;

                triStream.Append(VertexOutput(input[0].vertex + mul(transformationMatrix, float3(w, 0, 0)), float2(0, 0)));
                triStream.Append(VertexOutput(input[0].vertex + mul(transformationMatrix, float3(-w, 0, 0)), float2(1, 0)));
                triStream.Append(VertexOutput(input[0].vertex + mul(transformationMatrix, float3(0, 0, h)), float2(0.5, 1)));
            }

            fixed4 frag (g2f i) : SV_Target
            {
                return lerp(_BotCol, _TopCol, i.uv.y);
            }
            ENDCG
        }
    }
}
