Shader "Custom/VolumeRaymarch"
{
    Properties
    {
        _VolumeTex ("Volume Texture", 3D) = "" { }
        _StepSize ("Step Size", Range(0.001, 1)) = 0.05
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float3 worldPos : TEXCOORD0;
            };

            sampler3D _VolumeTex;
            float _StepSize;

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                float3 rayOrigin = i.worldPos;
                float3 rayDir = normalize(rayOrigin);
                float3 step = rayDir * _StepSize;
                float density = tex3D(_VolumeTex, rayOrigin).r;

                // Raymarching loop
                half4 color = half4(density, density, density, 1.0);
                return color;
            }
            ENDCG
        }
    }
}
