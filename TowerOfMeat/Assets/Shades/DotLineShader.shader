Shader "Meat/DotLineShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _RoundEdges("_RoundEdges", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Tranparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

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

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _RoundEdges;
            float4 _RoundEdges_ST;

            float4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.uv.x += _Time;
                o.uv.y += _Time.y;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 area = tex2D(_MainTex, i.uv);
                fixed4 edge = tex2D(_RoundEdges, i.uv);
                return fixed4(_Color.xyz, area.r);
                
            }
            ENDCG
        }
    }
}
