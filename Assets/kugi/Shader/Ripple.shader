Shader "Custom/Ripple"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Scale ("Scale", Range(0, 10)) = 0
        _Speed ("Speed", Range(0, 5)) = 1.0
        _Frequency ("Frequency", Range(0, 10)) = 0
        _Radius ("Radius", Range(0, 0.5)) = 0.5
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
        fixed _Radius;
        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
            float3 customValue;
        };

        void vert (inout appdata_full v, out Input o)
        {
            UNITY_INITIALIZE_OUTPUT(Input, o);
            half offsetvert = sqrt((v.vertex.x * v.vertex.x) + (v.vertex.z * v.vertex.z));
            half value = _Scale * abs(sin(_Time.y * _Speed + offsetvert * _Frequency));
            // half value = abs(sin(distance(float2(0.5, 0.5), v.vertex.xz) * _Time.y * _Speed));
            v.vertex.y += value;
            o.customValue = value;
        }
        
        void surf (Input IN, inout SurfaceOutput o)
        {
            float dist = distance(float2(0.5, 0.5), IN.uv_MainTex);
            float circle = step(dist, _Radius);
            o.Albedo = _Color.rgb;
            o.Alpha = _Color.a * circle;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
