Shader "Custom/Ripple"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Scale ("Scale", Range(0, 10)) = 0
        _Speed ("Speed", Range(-50, 50)) = 1.0
        _Frequency ("Scale", Range(-1, 1)) = 0
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue" = "Transparent" }
        LOD 200
        Cull Off
        
        CGPROGRAM
        #pragma surface surf Lambert vertex:vert alpha
        #pragma target 3.0
        
        #include "UnityCG.cginc"


        fixed4 _Color;
        fixed _Scale;
        fixed _Speed;
        fixed _Frequency;
        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
            float3 customValue;
        };

        void vert (inout appdata_full v, out Input o)
        {
            UNITY_INITIALIZE_OUTPUT(Input, o);
            half offsetvert = (v.vertex.x * v.vertex.x) + (v.vertex.z * v.vertex.z);
            half value = _Scale * sin(_Time.y * _Speed + offsetvert * _Frequency);
            v.vertex.y += value;
            o.customValue = value;
        }
        
        void surf (Input IN, inout SurfaceOutput o)
        {
            o.Albedo = _Color.rgb;
            o.Alpha = _Color.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
